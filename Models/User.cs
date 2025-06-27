using Microsoft.AspNetCore.Identity;

namespace RPGMakerAPI.Models
{
    public class User : IdentityUser<int>
    {
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public ICollection<Character> Characters { get; set; } = new List<Character>();
        public ICollection<AbilityTemplate> CreatedAbilities { get; set; } = new List<AbilityTemplate>();
    }
}