using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGMakerAPI.Models
{
    public class AttributeInstance
    {
        public int Id { get; set; }

        [Required]
        public int AbilityInstanceId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(AbilityInstanceId))]
        public AbilityInstance? AbilityInstance { get; set; }
    }
}
