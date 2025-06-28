using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RPGMakerAPI.Interfaces;

namespace RPGMakerAPI.Models
{
    public class FloatAttributeValueTemplate : IBelongsToUserChild
    {
        [Key]
        [ForeignKey(nameof(AttributeTemplate))]
        public int AttributeId { get; set; }

        [Required]
        public float? DefaultValue { get; set; }

        // Navigation Property
        public AttributeTemplate? AttributeTemplate { get; set; }

        public object? GetParent()
        {
            return AttributeTemplate;
        }
    }
}
