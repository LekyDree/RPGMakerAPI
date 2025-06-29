using System.ComponentModel.DataAnnotations;
using RPGMakerAPI.Interfaces;

namespace RPGMakerAPI.Models
{
    public class AbilityInstance : IHasCreatedAt, IBelongsToUserChild
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

        [Range(0, int.MaxValue)]
        public int PointCost { get; set; }

        [Range(0, int.MaxValue)]
        public int PointsAllocated { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Character? Character { get; set; }
        public AbilityTemplate? AbilityTemplate { get; set; }

        public object? GetParent()
        {
            return Character;
        }
    }
}
