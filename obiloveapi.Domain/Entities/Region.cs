// obiloveapi.Domain/Entities/Region.cs
using System.ComponentModel.DataAnnotations;
using obiloveapi.Domain.Common;

namespace obiloveapi.Domain.Entities
{
    public class Region : EntityBase
    {
        [Key]
        public int RegionId { get; set; }

        [Required, MaxLength(250)]
        public string Name { get; set; }
        
        // Additional properties for Region as needed
    }
}
