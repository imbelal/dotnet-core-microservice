using Order.Domain.Common;
using System.Collections.Generic;

namespace Order.Domain.Entities
{
    public class Order:BaseEntity
    {
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
