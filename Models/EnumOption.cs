using System.ComponentModel.DataAnnotations;
using RPGMakerAPI.Interfaces;

namespace RPGMakerAPI.Models
{
    public class EnumOption : IBelongsToUserChild
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; } = string.Empty;

        [Required]
        public int EnumDefinitionId { get; set; }

        public EnumDefinition? EnumDefinition { get; set; }

        public object? GetParent()
        {
            return EnumDefinition;
        }
    }

}