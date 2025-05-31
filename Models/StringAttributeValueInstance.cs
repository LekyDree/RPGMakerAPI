using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGMakerAPI.Models
{
    public class StringAttributeValueInstance
    {
        [Key]
        public int AttributeId { get; set; }

        [Required]
        public string DefaultValue { get; set; } = string.Empty;

        [Required]
        public string CurrentValue { get; set; } = string.Empty;

        [ForeignKey(nameof(AttributeId))]
        public AttributeInstance? AttributeInstance { get; set; }
    }
}
