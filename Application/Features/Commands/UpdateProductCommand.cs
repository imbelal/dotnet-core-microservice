using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IProductDbContext _context;
            public UpdateProductCommandHandler(IProductDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FirstOrDefaultAsync(a => a.Id == command.Id);

                if (product == null)
                {
                    return default;
                }
                else
                {
                    product.Name = command.Name;
                    product.Description = command.Description;
                    product.UnitPrice = command.UnitPrice;
                    product.Stock = command.Stock;
                    await _context.SaveChanges();

                    return product.Id;
                }
            }
        }
    }
}
