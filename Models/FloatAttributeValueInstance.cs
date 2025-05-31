using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGMakerAPI.Models
{
    public class FloatAttributeValueInstance
    {
        [Key]
        public int AttributeId { get; set; }

        [Required]
        public float DefaultValue { get; set; }

        [Required]
        public float CurrentValue { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public AttributeInstance? AttributeInstance { get; set; }
    }
}
