using Rent4Students.Application.DTOs.ListingFeature;

namespace Rent4Students.Application.Services.Interfaces.Enums
{
    public interface IListingFeatureService
    {
        Task<ResponseListingFeatureDTO> Create(ListingFeatureDTO featureDTO);
        Task<ResponseListingFeatureDTO> GetById(int Id);
        Task<List<ResponseListingFeatureDTO>> GetByIds(List<int> Ids);
        Task<List<ResponseListingFeatureDTO>> GetAll();
        Task Deleted(int Id);
    }
}
