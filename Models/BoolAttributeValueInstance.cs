using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGMakerAPI.Models
{
    public class BoolAttributeValueInstance
    {
        [Key]
        public int AttributeId { get; set; }

        [Required]
        public bool DefaultValue { get; set; }

        [Required]
        public bool CurrentValue { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public AttributeInstance? AttributeInstance { get; set; }
    }
}
