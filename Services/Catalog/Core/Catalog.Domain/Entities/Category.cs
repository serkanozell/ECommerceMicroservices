using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        public virtual ICollection<Product> Products { get; set; }
    }
}