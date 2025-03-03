// obiloveapi.Application/DTOs/User/UserResponse.cs
using obiloveapi.Domain.Enums;

namespace obiloveapi.Application.DTOs.User
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int BarangayId { get; set; }
        public UserStatus Status { get; set; }
    }
}
