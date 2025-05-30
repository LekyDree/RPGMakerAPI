using Microsoft.EntityFrameworkCore;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Data
{
    public class RPGMakerAPIContext : DbContext
    {
        public RPGMakerAPIContext(DbContextOptions<RPGMakerAPIContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<AbilityTemplate> AbilityTemplates { get; set; }
        public DbSet<AbilityInstance> AbilityInstances { get; set; }
        public DbSet<AttributeTemplate> AttributeTemplates { get; set; }
        public DbSet<AttributeInstance> AttributeInstances { get; set; }

        // Tag System
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AbilityTemplateTag> AbilityTemplateTags { get; set; }

        // Contributors
        public DbSet<AbilityTemplateLineage> AbilityTemplateLineage { get; set; }

        // Attribute Value Types (Templates)
        public DbSet<StringAttributeValueTemplate> StringAttributeValueTemplates { get; set; }
        public DbSet<FloatAttributeValueTemplate> FloatAttributeValueTemplates { get; set; }
        public DbSet<BoolAttributeValueTemplate> BoolAttributeValueTemplates { get; set; }

        // Attribute Value Types (Instances)
        public DbSet<StringAttributeValueInstance> StringAttributeValueInstances { get; set; }
        public DbSet<FloatAttributeValueInstance> FloatAttributeValueInstances { get; set; }
        public DbSet<BoolAttributeValueInstance> BoolAttributeValueInstances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite keys or additional configuration will go here
            // I’ll help with this as we move down the model list
        }
    }
}
