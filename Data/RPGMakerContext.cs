using Microsoft.EntityFrameworkCore;
using RPGMakerAPI.Models;

namespace RPGMakerAPI.Data
{
    public class RPGMakerContext : DbContext
    {
        public RPGMakerContext(DbContextOptions<RPGMakerContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<AbilityTemplate> AbilityTemplates { get; set; }
        public DbSet<AbilityTemplateLineage> AbilityTemplateLineages { get; set; }
        public DbSet<AbilityInstance> AbilityInstances { get; set; }

        public DbSet<AttributeTemplate> AttributeTemplates { get; set; }
        public DbSet<StringAttributeValueTemplate> StringAttributeValueTemplates { get; set; }
        public DbSet<FloatAttributeValueTemplate> FloatAttributeValueTemplates { get; set; }
        public DbSet<BoolAttributeValueTemplate> BoolAttributeValueTemplates { get; set; }
        public DbSet<EnumAttributeValueTemplate> EnumAttributeValueTemplates { get; set; }

        public DbSet<AttributeInstance> AttributeInstances { get; set; }
        public DbSet<StringAttributeValueInstance> StringAttributeValueInstances { get; set; }
        public DbSet<FloatAttributeValueInstance> FloatAttributeValueInstances { get; set; }
        public DbSet<BoolAttributeValueInstance> BoolAttributeValueInstances { get; set; }
        public DbSet<EnumAttributeValueInstance> EnumAttributeValueInstances { get; set; }

        public DbSet<EnumDefinition> EnumDefinitions { get; set; }
        public DbSet<EnumOption> EnumOptions { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<AbilityTag> AbilityTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite keys
            modelBuilder.Entity<AbilityTemplateLineage>()
                .HasKey(x => new { x.ChildAbilityTemplateId, x.ParentAbilityTemplateId });

            modelBuilder.Entity<AbilityTag>()
                .HasKey(x => new { x.AbilityTemplateId, x.TagId });

            // One-to-many AbilityTemplate → AttributeTemplate
            modelBuilder.Entity<AttributeTemplate>()
                .HasOne(at => at.AbilityTemplate)
                .WithMany(at => at.AttributeTemplates)
                .HasForeignKey(at => at.AbilityTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            // EnumAttributeValueTemplate default option FK
            modelBuilder.Entity<EnumAttributeValueTemplate>()
                .HasOne(e => e.DefaultOption)
                .WithMany()
                .HasForeignKey(e => e.DefaultOptionId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent default option from being deleted accidentally

            // EnumAttributeValueInstance current option FK
            modelBuilder.Entity<EnumAttributeValueInstance>()
                .HasOne(e => e.CurrentOption)
                .WithMany()
                .HasForeignKey(e => e.CurrentOptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
