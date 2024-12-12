namespace Rent4Students.Application.DTOs.Address
{
    public class AddressDTO
    {
        public string StreetAddress { get; set; }
        public string? AppartmentNumber { get; set; }
        public string? FloorNumber { get; set; }
        public string? BuildingNumber { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
