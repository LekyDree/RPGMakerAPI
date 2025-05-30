using System.ComponentModel.DataAnnotations;

namespace RPGMakerAPI.Models
{
    public class AbilityInstance
    {
        public int Id { get; set; }

        [Required]
        public int CharacterId { get; set; }

        [Required]
        public int AbilityTemplateId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public int PointCost { get; set; }

        [Required]
        public int PointsAllocated { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Character? Character { get; set; }
        public AbilityTemplate? AbilityTemplate { get; set; }
    }
}
