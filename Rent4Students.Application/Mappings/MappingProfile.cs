using AutoMapper;
using Rent4Students.Application.DTOs.Address;
using Rent4Students.Application.DTOs.Allergies;
using Rent4Students.Application.DTOs.Attributes;
using Rent4Students.Application.DTOs.Faculty;
using Rent4Students.Application.DTOs.FinancialHelpDocument;
using Rent4Students.Application.DTOs.Gender;
using Rent4Students.Application.DTOs.Hobbies;
using Rent4Students.Application.DTOs.Listing;
using Rent4Students.Application.DTOs.ListingFeature;
using Rent4Students.Application.DTOs.Nationality;
using Rent4Students.Application.DTOs.PropertyOwner;
using Rent4Students.Application.DTOs.Student;
using Rent4Students.Application.DTOs.University;
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
            ConfigureGenderMapping();
            ConfigureNationalityMapping();
            ConfigureAllergiesMapping();
            ConfigureAttributesMapping();
            ConfigureFacultyMapping();
            ConfigureUniversityMapping();
            ConfigureHobbyMapping();
            ConfigureStudentMapping();
            ConfigureFinancialHelpDocumentMapping();
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
            CreateMap<StudentListingPreferenceDTO, ListingFeature>();
            CreateMap<ListingFeature, ResponseListingFeatureDTO>();
        }

        private void ConfigureGenderMapping()
        {
            CreateMap<GenderDTO, Gender>();
            CreateMap<Gender, ResponseGenderDTO>();
        }

        private void ConfigureNationalityMapping()
        {
            CreateMap<NationalityDTO, Nationality>();
            CreateMap<Nationality, ResponseNationalityDTO>();
        }

        private void ConfigureAllergiesMapping()
        {
            CreateMap<AllergyDTO, Allergy>();
            CreateMap<Allergy, ResponseAllergiesDTO>();
        }

        private void ConfigureAttributesMapping()
        {
            CreateMap<StudentAttributeDTO, PersonalityAttribute>();
            CreateMap<PersonalityAttribute, ResponseStudentAttributesDTO>();
        }

        private void ConfigureFacultyMapping()
        {
            CreateMap<StudentFacultyDTO, Faculty>();
            CreateMap<Faculty, ResponseStudentFacultyDTO>();
            CreateMap<FacultyDTO, Faculty>();
            CreateMap<UpdateFacultyDTO, Faculty>();
            CreateMap<Faculty, ResponseFacultyDTO>()
                .ForMember(faculty => faculty.ProfilePhoto,
                opt => opt.MapFrom(entity => entity.ProfilePhoto.PhotoURL));
        }

        private void ConfigureUniversityMapping()
        {
            CreateMap<UniversityDTO, University>();
            CreateMap<University, ResponseStudentUniversityDTO>();
            CreateMap<University, ResponseUniversityDTO>()
                .ForMember(university => university.ProfilePhoto,
                opt => opt.MapFrom(entity => entity.ProfilePhoto.PhotoURL));
        }

        private void ConfigureHobbyMapping()
        {
            CreateMap<HobbyDTO, Hobby>();
            CreateMap<Hobby, ResponseHobbiesDTO>();
        }

        private void ConfigureStudentMapping()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<UpdateStudentDTO, Student>();
            CreateMap<Student, ResponseStudentDTO>()
                .ForMember(student => student.ProfilePhoto,
                    opt => opt.MapFrom(entity => entity.ProfilePhoto.PhotoURL))
                .ForMember(student => student.HobbiesIds,
                    opt => opt.MapFrom(entity => entity.Hobbies
                        .Select(hobby => hobby.HobbyId)))
                .ForMember(student => student.AllergiesIds,
                    opt => opt.MapFrom(entity => entity.Allergies
                        .Select(allergy => allergy.AllergyId)))
                .ForMember(student => student.AttributesIds,
                    opt => opt.MapFrom(entity => entity.Attributes
                        .Select(attribute => attribute.AttributeId)))
                .ForMember(student => student.LivingPreferencesIds,
                    opt => opt.MapFrom(entity => entity.LivingPreferences
                        .Select(preference => preference.ListingFeatureId)))
                .ForMember(student => student.FacultyId,
                    opt => opt.MapFrom(entity => entity.FacultyId));
        }

        private void ConfigureFinancialHelpDocumentMapping()
        {
            CreateMap<FinancialHelpDocument, ResponseStudentDocumentDTO>();
        }
    }
}
