using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductDbContext
    {
        DbSet<Product.Domain.Entities.Product> Products { get; set; }
        Task<int> SaveChanges();
    }
}
