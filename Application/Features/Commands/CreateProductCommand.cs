using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IProductDbContext _context;
            public CreateProductCommandHandler(IProductDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product.Domain.Entities.Product();
                product.Name = command.Name;
                product.UnitPrice = command.UnitPrice;
                product.Description = command.Description;
                product.Stock = command.Stock;
                _context.Products.Add(product);
                await _context.SaveChanges();

                return product.Id;
            }
        }
    }
}
