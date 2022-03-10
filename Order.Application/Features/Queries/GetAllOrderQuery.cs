using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Application.Interfaces;
using Order.Application.VMs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Features.Queries
{
    public class GetAllOrderQuery : IRequest<IEnumerable<OrderVm>>
    {
        public class GetAllOrderCommandHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<OrderVm>>
        {
            private readonly IOrderDbContext _context;
            public GetAllOrderCommandHandler(IOrderDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<OrderVm>> Handle(GetAllOrderQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<OrderVm> orders = new List<OrderVm>();

                var orderList = await _context.Orders.Include(x=> x.OrderItems).ToListAsync();
                if (orderList == null)
                {
                    return orders;
                }

                orders = orderList.Select(x => new OrderVm
                {
                    Id = x.Id,
                    TotalPrice = x.TotalPrice,
                    TotalQuantity = x.TotalQuantity,
                    OrderItems = x.OrderItems.Select(i => new OrderItemVm
                    {
                        OrderId = i.OrderId,
                        Price = i.Price,
                        ProductId = i.ProductId,
                        Quantity = i.Quantity,
                    }).ToList(),
                });

                return orders;
            }
        }
    }
}
