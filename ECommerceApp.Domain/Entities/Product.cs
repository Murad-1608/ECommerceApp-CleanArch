using ECommerceApp.Domain.Entities.Common;

namespace ECommerceApp.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
