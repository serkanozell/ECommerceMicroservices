namespace Catalog.Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CategoryId)
                   .IsRequired();

            builder.Property(p => p.Name)
                   .IsRequired();

            builder.Property(p => p.Price)
                   .IsRequired();

            builder.Property(p => p.Description)
                   .IsRequired();

            builder.HasOne(p => p.Category)
                   .WithMany(p => p.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}