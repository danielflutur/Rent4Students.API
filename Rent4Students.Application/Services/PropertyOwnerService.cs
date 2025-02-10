using AutoMapper;
using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.Address;
using Rent4Students.Application.DTOs.PropertyOwner;
using Rent4Students.Application.DTOs.Student;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Repositories;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Application.Services
{
    public class PropertyOwnerService : IPropertyOwnerService
    {
        private readonly IPropertyOwnerRepository _ownerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IStoredPhotoService _storedPhotoService;
        private readonly IMapper _mapper;

        public PropertyOwnerService(
            IPropertyOwnerRepository ownerRepository,
            IAddressRepository addressRepository,
            IStoredPhotoService storedPhotoService,
            IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _addressRepository = addressRepository;
            _storedPhotoService = storedPhotoService;
            _mapper = mapper;
        }

        public async Task<ResponsePropertyOwnerDTO> Create(PropertyOwnerDTO ownerDTO)
        {
            var photo = await _storedPhotoService.Create(ownerDTO.ProfilePhoto);
            ownerDTO.ProfilePhoto = null;
            var mappedOwner = _mapper.Map<PropertyOwner>(ownerDTO);
            mappedOwner.ProfilePhoto = photo;

            var owner = await _ownerRepository.Create(mappedOwner);
            owner.Address = await AddAddress(ownerDTO.Address, owner);
            owner.AddressId = owner.Address.Id;

            await _ownerRepository.Update(owner);

            photo.PropertyOwner = owner;
            photo.PropertyOwnerId = owner.Id;

            return _mapper.Map<ResponsePropertyOwnerDTO>(owner);
        }

        public async Task<ResponsePropertyOwnerDTO> AddProfilePhoto(IFormFile profilePhoto, Guid id)
        {
            var photo = await _storedPhotoService.Create(profilePhoto);
            var owner = await _ownerRepository.GetById(id);
            owner.ProfilePhoto = photo;
            owner.ProfilePhotoId = photo.Id;
            photo.PropertyOwner = owner;
            photo.PropertyOwnerId = owner.Id;

            await _ownerRepository.Update(owner);

            return _mapper.Map<ResponsePropertyOwnerDTO>(owner);
        }

        public async Task Deleted(Guid Id)
        {
            var owner = await _ownerRepository.GetById(Id);

            if (owner is null)
            {
                throw new KeyNotFoundException();
            }

            await _ownerRepository.Delete(owner);
        }

        public async Task<List<ResponsePropertyOwnerDTO>> GetAll()
        {
            return _mapper.Map<List<ResponsePropertyOwnerDTO>>(await _ownerRepository.GetAll());
        }

        public async Task<ResponsePropertyOwnerDTO> GetById(Guid Id)
        {
            return _mapper.Map<ResponsePropertyOwnerDTO>(await _ownerRepository.GetById(Id));
        }

        public async Task<ResponsePropertyOwnerDTO> Update(PropertyOwnerDTO ownerDTO)
        {
            return _mapper.Map<ResponsePropertyOwnerDTO>(await _ownerRepository.Update(_mapper.Map<PropertyOwner>(ownerDTO)));
        }

        private async Task<Address> AddAddress(AddressDTO addressDTO, PropertyOwner owner)
        {
            var mappedAddress = _mapper.Map<Address>(addressDTO);
            mappedAddress.PropertyOwnerId = owner.Id;
            mappedAddress.PropertyOwner = owner;

            return await _addressRepository.Create(mappedAddress);
        }
    }
}
