using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RPGMakerAPI.Interfaces;

namespace RPGMakerAPI.Models
{
    public class FloatAttributeValueInstance : IBelongsToUserChild
    {
        [Key]
        public int AttributeId { get; set; }

        [Required]
        public float? DefaultValue { get; set; }

        [Required]
        public float? CurrentValue { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public AttributeInstance? AttributeInstance { get; set; }

        public object? GetParent()
        {
            return AttributeInstance;
        }
    }
}
