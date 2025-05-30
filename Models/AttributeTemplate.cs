using System.ComponentModel.DataAnnotations;

namespace RPGMakerAPI.Models
{
    public class AttributeTemplate
    {
        public int Id { get; set; }

        [Required]
        public int AbilityTemplateId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation Properties
        public AbilityTemplate? AbilityTemplate { get; set; }
    }
}
