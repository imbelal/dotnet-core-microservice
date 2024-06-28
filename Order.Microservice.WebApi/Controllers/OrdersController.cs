using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Features.Commands;
using Order.Application.Features.Queries;
using Shared.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Microservice.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private readonly IBus _bus;
        public OrdersController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            var res = await Mediator.Send(command);

            if (res.OrderItems.Count > 0)
            {
                OrderModel order = new OrderModel
                {
                    TotalPrice = res.TotalPrice,
                    TotalQuantity = res.TotalQuantity,
                    OrderItems = res.OrderItems.Select(x => new OrderItemModel
                    {
                        OrderId = x.OrderId,
                        Price = x.Price,
                        ProductId = x.ProductId,
                        Quantity = x.Quantity
                    }).ToList()
                };

                Uri uri = new Uri("rabbitmq://localhost/orderQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(order);
                return Ok(res.Id);
            }

            return Ok(res.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllOrderQuery()));
        }
    }
}
