// obiloveapi.Domain/Entities/User.cs
using System.ComponentModel.DataAnnotations;
using obiloveapi.Domain.Common;
using obiloveapi.Domain.Enums;

namespace obiloveapi.Domain.Entities
{
    public class User : EntityBase
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string? MiddleName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        // Contact info
        [MaxLength(250)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        // Verification status flag
        public UserStatus Status { get; set; } = UserStatus.Pending;

        // Navigation property for a normalized Address
        public virtual Address Address { get; set; }
    }
}
