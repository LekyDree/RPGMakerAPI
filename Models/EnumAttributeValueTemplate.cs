using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGMakerAPI.Models
{
    public class EnumAttributeValueTemplate
    {
        [Key]
        [ForeignKey(nameof(AttributeTemplate))]
        public int AttributeId { get; set; }

        [Required]
        public int EnumDefinitionId { get; set; }

        public AttributeTemplate? AttributeTemplate { get; set; }
        public EnumDefinition? EnumDefinition { get; set; }

        public int DefaultOptionId { get; set; }

        public EnumOption? DefaultOption { get; set; }
    }


}