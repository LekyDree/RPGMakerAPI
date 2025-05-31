using System.ComponentModel.DataAnnotations;

namespace RPGMakerAPI.Models
{
    public class EnumDefinition
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