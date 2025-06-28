using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RPGMakerAPI.Interfaces;

namespace RPGMakerAPI.Models
{
    public class BoolAttributeValueInstance : IBelongsToUserChild
    {
        [Key]
        public int AttributeId { get; set; }

        [Required]
        public bool? DefaultValue { get; set; }

        public bool CurrentValue { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public AttributeInstance? AttributeInstance { get; set; }

        public object? GetParent()
        {
            return AttributeInstance;
        }
    }
}
