using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetProductByIdQuery : IRequest<Product.Domain.Entities.Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product.Domain.Entities.Product>
        {
            private readonly IProductDbContext _context;
            public GetProductByIdQueryHandler(IProductDbContext context)
            {
                _context = context;
            }
            public async Task<Product.Domain.Entities.Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FirstOrDefaultAsync(a => a.Id == query.Id);
                if (product == null) return null;
                return product;
            }
        }
    }
}
