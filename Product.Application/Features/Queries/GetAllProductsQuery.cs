using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product.Domain.Entities.Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product.Domain.Entities.Product>>
        {
            private readonly IProductDbContext _context;
            public GetAllProductsQueryHandler(IProductDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Product.Domain.Entities.Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                if (productList == null)
                {
                    return null;
                }

                return productList;
            }
        }
    }
}
