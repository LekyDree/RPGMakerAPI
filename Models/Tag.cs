using System.ComponentModel.DataAnnotations;

namespace RPGMakerAPI.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        // Navigation
        public ICollection<AbilityTag>? AbilityTags { get; set; }
    }
}
