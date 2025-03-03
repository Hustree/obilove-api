// obiloveapi.Application/DTOs/Citizen/CitizenUpdateRequest.cs
namespace obiloveapi.Application.DTOs.Citizen
{
    public class CitizenUpdateRequest
    {
        public int CitizenId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        // Optionally allow updating the address as well
        public string Street { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int BarangayId { get; set; }
        // Optionally update status (for admins)
        public string Status { get; set; }
    }
}
