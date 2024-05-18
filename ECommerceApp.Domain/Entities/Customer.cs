using ECommerceApp.Domain.Entities.Common;

namespace ECommerceApp.Domain.Entities
{
    public sealed class Customer : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
