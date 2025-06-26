using System.ComponentModel.DataAnnotations;
using RPGMakerAPI.Interfaces;

namespace RPGMakerAPI.Models
{
    public class User : IHasCreatedAt
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public ICollection<Character> Characters { get; set; } = new List<Character>();
        public ICollection<AbilityTemplate> CreatedAbilities { get; set; } = new List<AbilityTemplate>();
    }
}