using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGMakerAPI.Models
{
    public class FloatAttributeValueTemplate
    {
        [Key]
        [ForeignKey(nameof(AttributeTemplate))]
        public int AttributeId { get; set; }

        [Required]
        public float? DefaultValue { get; set; }

        // Navigation Property
        public AttributeTemplate? AttributeTemplate { get; set; }
    }
}
