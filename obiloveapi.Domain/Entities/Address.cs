// obiloveapi.Domain/Entities/Address.cs
using System.ComponentModel.DataAnnotations;
using obiloveapi.Domain.Common;

namespace obiloveapi.Domain.Entities
{
    public class Address : EntityBase
    {
        [Key]
        public int AddressId { get; set; }

        [Required, MaxLength(250)]
        public string? Street { get; set; }

        // Example: Foreign key to Province
        public int? ProvinceId { get; set; }
        public virtual Province Province { get; set; }

        // You can add City/Municipality and Barangay similarly
        public int? CityId { get; set; }
        // public virtual City City { get; set; }

        public int? BarangayId { get; set; }
        // public virtual Barangay Barangay { get; set; }
    }
}
