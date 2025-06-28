using System.ComponentModel.DataAnnotations;
using RPGMakerAPI.Interfaces;

namespace RPGMakerAPI.Models
{
    public class Character : IHasCreatedAt, IBelongsToUser
    {
        public int Id { get; set; }

        [Required]
        public int CreatedByUserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public User? CreatedByUser { get; set; }
        public ICollection<AbilityInstance> AbilityInstances { get; set; } = new List<AbilityInstance>();
    }
}