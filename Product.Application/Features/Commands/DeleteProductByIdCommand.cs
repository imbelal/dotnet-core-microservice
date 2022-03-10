using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private readonly IProductDbContext _context;
            public DeleteProductByIdCommandHandler(IProductDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FirstOrDefaultAsync(a => a.Id == command.Id);
                if (product == null) return default;
                _context.Products.Remove(product);
                await _context.SaveChanges();

                return product.Id;
            }
        }
    }
}
