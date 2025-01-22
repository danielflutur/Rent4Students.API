using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using Rent4Students.Application.DTOs.ListingFeature;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Application.Services.Interfaces.Enums;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

public class Detection
{
    public RectangleF BoundingBox { get; set; }
    public float Confidence { get; set; }
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public float ClassScore { get; set; }
}

public class ObjectDetectionService : IObjectDetectionService
{
    private readonly IListingFeatureService _featuresService;
    private readonly InferenceSession _session;
    private readonly Dictionary<int, string> _labels;
    private readonly int[] _tensorDimensions = [1, 3, 640, 640];

    private const string MODEL_INPUT_NAME = "images";
    private const string MODEL_PATH = "C:\\Users\\Daniel\\Documents\\BIM2024\\Rent4Students.API\\Rent4Students.Application\\Models\\yolov5x6.onnx";
    private const string LABELS_PATH = "C:\\Users\\Daniel\\Documents\\BIM2024\\Rent4Students.API\\Rent4Students.Application\\Models\\Lables\\coco_labels.txt";
    private const int TARGET_WIDTH = 640;
    private const int TARGET_HEIGHT = 640;
    private const int NUMBER_OF_ATTIBUTES = 85;
    private const int NUMBER_OF_CLASSES = 80;
    private const float CONFIDENCE_THRESHOLD = 0.4f;
    private const float NMS_THRESHOLD = 0.45f;

    public ObjectDetectionService(
        IListingFeatureService featureService)
    {
        _featuresService = featureService;
        _session = new InferenceSession(MODEL_PATH);
        _labels = LoadLabels(LABELS_PATH);
    }

    public async Task<List<ResponseListingFeatureDTO>> DetectObjects(byte[] imageData)
    {
        var inputTensor = PreprocessImage(imageData);
        var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor(MODEL_INPUT_NAME, inputTensor)
        };

        try
        {
            return await ProcessOutput(_session.Run(inputs));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during inference: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
            throw;
        }
    }

    private DenseTensor<Float16> PreprocessImage(byte[] imageData)
    {
        var tensor = new DenseTensor<Float16>(_tensorDimensions);
        using var image = Image.Load<Rgb24>(imageData);

        image.Mutate(x => x.Resize(TARGET_WIDTH, TARGET_HEIGHT));

        for (int y = 0; y < TARGET_HEIGHT; y++)
        {
            for (int x = 0; x < TARGET_WIDTH; x++)
            {
                var pixel = image[x, y];
                tensor[0, 0, y, x] = (Float16)(pixel.R / 255f);
                tensor[0, 1, y, x] = (Float16)(pixel.G / 255f);
                tensor[0, 2, y, x] = (Float16)(pixel.B / 255f);
            }
        }

        return tensor;
    }

    private async Task<List<ResponseListingFeatureDTO>> ProcessOutput(IDisposableReadOnlyCollection<DisposableNamedOnnxValue> results)
    {
        var output = results.First().AsEnumerable<Float16>().Select(number => number.ToFloat()).ToArray();
        var numDetections = output.Length / NUMBER_OF_ATTIBUTES;

        var detections = new List<Detection>();
        for (int i = 0; i < numDetections; i++)
        {
            int offset = i * NUMBER_OF_ATTIBUTES;
            float confidence = output[offset + 4];

            if (confidence < CONFIDENCE_THRESHOLD)
                continue;

            float[] classProbs = output.Skip(offset + 5).Take(NUMBER_OF_CLASSES).ToArray();
            int classId = Array.IndexOf(classProbs, classProbs.Max());
            float classConfidence = classProbs[classId];

            float x = output[offset];
            float y = output[offset + 1];
            float width = output[offset + 2];
            float height = output[offset + 3];

            detections.Add(new Detection
            {
                BoundingBox = new RectangleF(x - width / 2, y - height / 2, width, height),
                Confidence = confidence,
                ClassId = classId,
                ClassName = _labels.TryGetValue(classId, out var label) ? label : $"Class {classId}",
                ClassScore = classConfidence
            });
        }

        return await FoundFacilities(ApplyNMS(detections, NMS_THRESHOLD));
    }

    private List<Detection> ApplyNMS(List<Detection> detections, float nmsThreshold)
    {
        var filteredDetections = new List<Detection>();

        foreach (var group in detections.GroupBy(d => d.ClassId))
        {
            var sortedGroup = group.OrderByDescending(d => d.Confidence).ToList();

            while (sortedGroup.Any())
            {
                var top = sortedGroup.First();
                filteredDetections.Add(top);
                sortedGroup.RemoveAt(0);

                sortedGroup = sortedGroup
                    .Where(d => IoU(top.BoundingBox, d.BoundingBox) < nmsThreshold)
                    .ToList();
            }
        }

        return filteredDetections;
    }

    private float IoU(RectangleF box1, RectangleF box2)
    {
        var intersection = RectangleF.Intersect(box1, box2);
        float intersectionArea = intersection.Width * intersection.Height;
        float unionArea = box1.Width * box1.Height + box2.Width * box2.Height - intersectionArea;

        return intersectionArea / unionArea;
    }

    private Dictionary<int, string> LoadLabels(string labelsPath)
    {
        if (!File.Exists(labelsPath))
            throw new FileNotFoundException($"Label file not found: {labelsPath}");

        var labels = File.ReadAllLines(labelsPath)
                         .Select((label, index) => new { label, index })
                         .ToDictionary(x => x.index, x => x.label);

        return labels;
    }

    private async Task<List<ResponseListingFeatureDTO>> FoundFacilities(List<Detection> detectedObjects)
    {
        var features = await _featuresService.GetAll();
        var facilities = features
            .Where(feature => string.Equals(feature.Name, "facilities", StringComparison.OrdinalIgnoreCase))
            .ToDictionary(facility => facility.Value.ToLower(), facility => facility);

        var furnitureKeywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "dining table", "bed", "couch", "chair"
            };

        var foundFacilities = detectedObjects
            .Select(detected => facilities.TryGetValue(detected.ClassName.ToLower(), out var matchingFacility) ? matchingFacility : null)
            .Where(matchingFacility => matchingFacility != null)
            .GroupBy(facility => facility.Id)
            .Select(group => group.First())
            .ToList();

        if (detectedObjects.Any(detected => furnitureKeywords.Contains(detected.ClassName)))
        {
            var furnitureFacility = features.FirstOrDefault(feature =>
                string.Equals(feature.Value.ToLower(), "furniture", StringComparison.OrdinalIgnoreCase));

            if (furnitureFacility != null)
            {
                foundFacilities.Add(furnitureFacility);
            }
        }

        return foundFacilities;
    } 
}
