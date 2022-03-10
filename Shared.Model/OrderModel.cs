using System.Collections.Generic;

namespace Shared.Model
{
    public class OrderModel
    {
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
    }
}
