﻿using Microsoft.AspNetCore.Http;
using Rent4Students.Application.DTOs.Address;

namespace Rent4Students.Application.DTOs.Listing
{
    public class ListingDTO
    {
        public string Title {  get; set; }
        public string Description { get; set; }
        public int RentPrice { get; set; }
        public int? DepositAmount { get; set; }
        public int? BuildingYear { get; set; }
        public float Surface { get; set; }
        public int ListingTypeId { get; set; }
        public AddressDTO Address { get; set; }
        public Guid OwnerId { get; set; }
        public List<IFormFile> Photos { get; set; }
        public List<int> AmenitiesIds { get; set; }
    }
}
