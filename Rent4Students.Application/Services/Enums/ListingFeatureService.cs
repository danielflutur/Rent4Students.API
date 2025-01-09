using AutoMapper;
using Rent4Students.Application.DTOs.ListingFeature;
using Rent4Students.Application.Services.Interfaces.Enums;
using Rent4Students.Domain.Entities.Enums;
using Rent4Students.Infrastructure.Repositories.Interfaces.Enums;

namespace Rent4Students.Application.Services.Enums
{
    public class ListingFeatureService : IListingFeatureService
    {
        private readonly IListingFeatureRepository _featureRepository;
        private readonly IMapper _mapper;

        public ListingFeatureService(
            IListingFeatureRepository featureRepository,
            IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }

        public async Task<ResponseListingFeatureDTO> Create(ListingFeatureDTO featureDTO)
        {
            return _mapper.Map<ResponseListingFeatureDTO>(await _featureRepository.Create(_mapper.Map<ListingFeature>(featureDTO)));
        }

        public async Task Deleted(int Id)
        {
            await _featureRepository.Delete(Id);
        }

        public async Task<List<ResponseListingFeatureDTO>> GetAll()
        {
            return _mapper.Map<List<ResponseListingFeatureDTO>>(await _featureRepository.GetAll());
        }

        public async Task<ResponseListingFeatureDTO> GetById(int Id)
        {
            return _mapper.Map<ResponseListingFeatureDTO>(await _featureRepository.GetById(Id));
        }

        public async Task<List<ResponseListingFeatureDTO>> GetByIds(List<int> Ids)
        {
            return _mapper.Map<List<ResponseListingFeatureDTO>>(await _featureRepository.GetByIds(Ids));
        }
    }
}
