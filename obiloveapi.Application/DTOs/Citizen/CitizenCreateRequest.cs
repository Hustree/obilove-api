// obiloveapi.Application/DTOs/Citizen/CitizenCreateRequest.cs
namespace obiloveapi.Application.DTOs.Citizen
{
    public class CitizenCreateRequest
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        // Address details
        public string Street { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int BarangayId { get; set; }
    }
}
