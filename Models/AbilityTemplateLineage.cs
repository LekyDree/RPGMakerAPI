using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGMakerAPI.Models
{
    public class AbilityTemplateLineage
    {
        [Required]
        public int ChildAbilityTemplateId { get; set; }

        [Required]
        public int ParentAbilityTemplateId { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(ChildAbilityTemplateId))]
        public AbilityTemplate ChildAbilityTemplate { get; set; } = null!;

        [ForeignKey(nameof(ParentAbilityTemplateId))]
        public AbilityTemplate ParentAbilityTemplate { get; set; } = null!;
    }
}
