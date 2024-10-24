using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string Description { get; set; } = default!;

        public virtual Category Category { get; set; }

        public Product()
        {

        }
    }
}