using AutoMapper;
using Rent4Students.Application.DTOs.University;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Repositories.Interfaces;
using System.Text.RegularExpressions;

namespace Rent4Students.Application.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IStoredPhotoService _photoService;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public UniversityService(
            IUniversityRepository universityRepository,
            IFacultyRepository facultyRepository,
            IStoredPhotoService photoService,
            IAddressRepository addressRepository,
            IMapper mapper)
        {
            _universityRepository = universityRepository;
            _facultyRepository = facultyRepository;
            _photoService = photoService;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<ResponseUniversityDTO> Create(UniversityDTO universityDTO)
        {
            var photo = await _photoService.Create(universityDTO.ProfilePhoto);
            universityDTO.ProfilePhoto = null;

            var mappedUniversity = _mapper.Map<University>(universityDTO);
            mappedUniversity.ProfilePhoto = photo;
            mappedUniversity.ProfilePhotoId = photo.Id;

            var university = await _universityRepository.Create(mappedUniversity);

            var mappedAddress = _mapper.Map<Address>(universityDTO.Address);
            mappedAddress.UniversityId = university.Id;
            mappedAddress.University = university;

            university.Address = await _addressRepository.Create(mappedAddress);
            university.AddressId = university.Address.Id;

            bool isCifValid = await ValidateCIF(university.CIF);
            university.IsValidated = isCifValid;

            await _universityRepository.Update(university);

            photo.University = university;
            photo.UniversityId = university.Id;

            return _mapper.Map<ResponseUniversityDTO>(university);
        }

        public async Task Delete(Guid id)
        {
            var university = await _universityRepository.GetById(id);

            if (university is null)
            {
                throw new KeyNotFoundException();
            }

            await _universityRepository.Delete(university);
        }

        public async Task<List<ResponseUniversityDTO>> GetAll()
        {
            return _mapper.Map<List<ResponseUniversityDTO>>(await _universityRepository.GetAll());
        }

        public async Task<ResponseUniversityDTO> GetById(Guid id)
        {
            return _mapper.Map<ResponseUniversityDTO>(await _universityRepository.GetById(id));
        }

        public async Task<ResponseUniversityDTO> Update(UniversityDTO universityDTO)
        {
            return _mapper.Map<ResponseUniversityDTO>(await _universityRepository.Update(_mapper.Map<University>(universityDTO)));
        }

        private async Task<bool> ValidateCIF(string cif)
        {
            if (string.IsNullOrWhiteSpace(cif))
                return false;

            cif = Regex.Replace(cif, "[^0-9]", "");
            if (cif.Length < 5)
                return false;

            var baseAddress = new Uri("https://api.openapi.ro/");
            var requestUri = $"api/companies/{cif}";

            try
            {
                using (var httpClient = new HttpClient { BaseAddress = baseAddress })
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("x-api-key", "JS5NGFTsz-EiM4kfcByaAtkiJLtMkcedsBox8sweMZn-cAyAEw");

                    using (var response = await httpClient.GetAsync(requestUri))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string responseData = await response.Content.ReadAsStringAsync();
                            return !string.IsNullOrEmpty(responseData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Optionally log the exception for debugging.
                Console.WriteLine($"Error validating CIF: {ex.Message}");
            }
            return false;
        }
    }
}
