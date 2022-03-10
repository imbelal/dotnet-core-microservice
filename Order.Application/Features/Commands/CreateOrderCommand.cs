using MediatR;
using Order.Application.Dtos;
using Order.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Features.Commands
{
    public class CreateOrderCommand : IRequest<Domain.Entities.Order>
    {
        public List<OrderItemDto> OrderItems { get; set; }
        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Domain.Entities.Order>
        {
            private readonly IOrderDbContext _context;
            public CreateOrderCommandHandler(IOrderDbContext context)
            {
                _context = context;
            }
            public async Task<Domain.Entities.Order> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
            {
                var order = new Domain.Entities.Order();
                order.TotalQuantity = command.OrderItems.Sum(x=> x.Quantity);
                order.TotalPrice = command.OrderItems.Sum(x => x.Quantity * x.Price);
                order.OrderItems = command.OrderItems.Select(x=> new Domain.Entities.OrderItem { 
                    OrderId = order.Id,
                    ProductId = x.ProductId,
                    Price = x.Price,
                    Quantity = x.Quantity
                }).ToList();
                _context.Orders.Add(order);
                await _context.SaveChanges();

                return order;
            }
        }
    }
}
