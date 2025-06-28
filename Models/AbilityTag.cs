using System.ComponentModel.DataAnnotations;

namespace RPGMakerAPI.Models
{
    public class AbilityTag
    {
        [Required]
        public int AbilityTemplateId { get; set; }

        [Required]
        public int TagId { get; set; }

        // Navigation
        public AbilityTemplate? AbilityTemplate { get; set; }

        public Tag? Tag { get; set; }
    }
}
