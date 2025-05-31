using System.ComponentModel.DataAnnotations;

namespace RPGMakerAPI.Models
{
    public class EnumOption
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; } = string.Empty;

        [Required]
        public int EnumDefinitionId { get; set; }

        public EnumDefinition? EnumDefinition { get; set; }
    }

}