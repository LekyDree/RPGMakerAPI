using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGMakerAPI.Models
{
    public class StringAttributeValueTemplate
    {
        [Key]
        [ForeignKey(nameof(AttributeTemplate))]
        public int AttributeId { get; set; }

        [Required]
        public string DefaultValue { get; set; } = string.Empty;

        // Navigation Property
        public AttributeTemplate? AttributeTemplate { get; set; }
    }
}
