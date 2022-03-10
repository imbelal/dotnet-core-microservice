using MassTransit;
using Shared.Model;
using System.Threading.Tasks;

namespace Product.Microservice.WebApi.Consumers
{
    public class OrderConsumer : IConsumer<OrderModel>
    {
        public async Task Consume(ConsumeContext<OrderModel> context)
        {
            var data = context.Message;
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
        }
    }
}
