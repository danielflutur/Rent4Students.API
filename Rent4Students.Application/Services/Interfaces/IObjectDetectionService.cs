using Rent4Students.Application.DTOs.ListingFeature;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IObjectDetectionService
    {
        Task<List<ResponseListingFeatureDTO>> DetectObjects(byte[] imageData);
    }
}
