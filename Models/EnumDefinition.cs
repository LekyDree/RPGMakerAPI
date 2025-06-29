using System.ComponentModel.DataAnnotations;
using RPGMakerAPI.Interfaces;

namespace RPGMakerAPI.Models
{
    public class EnumDefinition : IBelongsToUser
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int CreatedByUserId { get; set; }

        public User? CreatedByUser { get; set; }

        public ICollection<EnumOption> Options { get; set; } = new List<EnumOption>();
    }
}