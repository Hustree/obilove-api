// obiloveapi.Domain/Entities/Citizen.cs
using System.ComponentModel.DataAnnotations;
using obiloveapi.Domain.Common;
using obiloveapi.Domain.Enums;

namespace obiloveapi.Domain.Entities
{
    public class Citizen : EntityBase
    {
        [Key]
        public int CitizenId { get; set; }

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
        public CitizenStatus Status { get; set; } = CitizenStatus.Pending;

        // Navigation property for a normalized Address
        public virtual Address Address { get; set; }
    }
}
