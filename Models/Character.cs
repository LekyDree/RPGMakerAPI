using System.ComponentModel.DataAnnotations;

namespace RPGMakerAPI.Models
{
    public class Character
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public User? User { get; set; }
        public ICollection<AbilityInstance> AbilityInstances { get; set; } = new List<AbilityInstance>();
    }
}