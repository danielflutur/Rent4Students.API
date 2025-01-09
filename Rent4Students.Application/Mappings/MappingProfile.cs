using AutoMapper;
using Rent4Students.Application.DTOs.Address;
using Rent4Students.Application.DTOs.Listing;
using Rent4Students.Application.DTOs.ListingFeature;
using Rent4Students.Application.DTOs.PropertyOwner;
using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ConfigureListingMapping();
            ConfigureAddressMapping();
            ConfigurePropertyOwnerMapping();
            ConfigureListingFeatureMapping();
        }

        private void ConfigureListingMapping()
        {
            CreateMap<ListingDTO, Listing>();
            CreateMap<Listing, ResponseListingDTO>()
                .ForMember(listing => listing.Photos,
                opt => opt.MapFrom(entity => entity.Photos.Select(photo => photo.PhotoURL)))
                .ForMember(listing => listing.AmenitiesIds,
                opt => opt.MapFrom(entity => entity.Amenities.Select(amenity => amenity.ListingFeatureId)));
        }

        private void ConfigureAddressMapping()
        {
            CreateMap<AddressDTO, Address>();
            CreateMap<Address, ResponseAddressDTO>();
        }

        private void ConfigurePropertyOwnerMapping()
        {
            CreateMap<PropertyOwnerDTO, PropertyOwner>();
            CreateMap<PropertyOwner, ResponsePropertyOwnerDTO>()
                .ForMember(owner => owner.ProfilePhoto,
                opt => opt.MapFrom(entity => entity.ProfilePhoto.PhotoURL));
        }

        private void ConfigureListingFeatureMapping()
        {
            CreateMap<ListingFeatureDTO, ListingFeature>();
            CreateMap<ListingFeature, ResponseListingFeatureDTO>();
        }
    }
}
