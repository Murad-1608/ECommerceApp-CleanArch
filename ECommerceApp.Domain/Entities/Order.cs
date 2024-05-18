using ECommerceApp.Domain.Entities.Common;

namespace ECommerceApp.Domain.Entities
{
    public sealed class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }
}
