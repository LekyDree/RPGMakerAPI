using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGMakerAPI.Models
{
    public class AbilityTemplate
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)] // Optional, adjust as needed
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public int PointCost { get; set; }

        public bool IsDefault { get; set; }

        [ForeignKey(nameof(CreatedByUser))]
        public int CreatedByUserId { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public User CreatedByUser { get; set; } = null!;
        public ICollection<AbilityTag> Tags { get; set; } = new List<AbilityTag>();
        public ICollection<AttributeTemplate> Attributes { get; set; } = new List<AttributeTemplate>();
    }
}
