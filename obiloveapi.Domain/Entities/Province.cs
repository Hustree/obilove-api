// obiloveapi.Domain/Entities/Province.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using obiloveapi.Domain.Common;

namespace obiloveapi.Domain.Entities
{
    public class Province : EntityBase
    {
        [Key]
        public int ProvinceId { get; set; }

        [Required, MaxLength(250)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Abbreviation { get; set; }

        // Proper relationship to a Region entity
        [ForeignKey("Region")]
        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
