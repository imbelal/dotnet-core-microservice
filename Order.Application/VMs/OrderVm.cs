using System.Collections.Generic;

namespace Order.Application.VMs
{
    public class OrderVm
    {
        public int Id { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemVm> OrderItems { get; set; }
    }
}
