// obiloveapi.Application/DTOs/Citizen/CitizenResponse.cs
using obiloveapi.Domain.Enums;

namespace obiloveapi.Application.DTOs.Citizen
{
    public class CitizenResponse
    {
        public int CitizenId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int BarangayId { get; set; }
        public CitizenStatus Status { get; set; }
    }
}
