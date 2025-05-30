using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGMakerAPI.Models
{
    public class BoolAttributeValueTemplate
    {
        [Key]
        [ForeignKey(nameof(AttributeTemplate))]
        public int AttributeId { get; set; }

        [Required]
        public bool DefaultValue { get; set; }

        // Navigation Property
        public AttributeTemplate? AttributeTemplate { get; set; }
    }
}
