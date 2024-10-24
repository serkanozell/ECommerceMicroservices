namespace Catalog.Persistance.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasMany(c => c.Products)
                   .WithOne(c => c.Category)
                   .HasForeignKey(c => c.CategoryId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}