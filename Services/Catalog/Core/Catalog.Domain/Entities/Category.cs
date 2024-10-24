using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public virtual ICollection<Product> Products { get; set; }

        public static Category Create(string name, string description)
        {
            return new Category
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description
            };
        }

    }
}