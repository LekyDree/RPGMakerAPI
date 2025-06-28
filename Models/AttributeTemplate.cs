using System.ComponentModel.DataAnnotations;
using RPGMakerAPI.Interfaces;

namespace RPGMakerAPI.Models
{
    public class AttributeTemplate : IBelongsToUserChild
    {
        public int Id { get; set; }

        [Required]
        public int AbilityTemplateId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation Properties
        public AbilityTemplate? AbilityTemplate { get; set; }

        public object? GetParent()
        {
            return AbilityTemplate;
        }
    }
}
