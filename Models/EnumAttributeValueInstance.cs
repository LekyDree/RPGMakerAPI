using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RPGMakerAPI.Interfaces;

namespace RPGMakerAPI.Models
{
    public class EnumAttributeValueInstance : IBelongsToUserChild
    {
        [Key]
        public int AttributeId { get; set; }

        [Required]
        public int DefaultOptionId { get; set; }

        [Required]
        public int CurrentOptionId { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public AttributeInstance? AttributeInstance { get; set; }

        [ForeignKey(nameof(DefaultOptionId))]
        public EnumOption? DefaultOption { get; set; }

        [ForeignKey(nameof(CurrentOptionId))]
        public EnumOption? CurrentOption { get; set; }

        public object? GetParent()
        {
            return AttributeInstance;
        }
    }
}
