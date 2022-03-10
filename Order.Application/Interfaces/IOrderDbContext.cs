using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Order.Application.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Order.Domain.Entities.Order> Orders { get; set; }
        DbSet<Order.Domain.Entities.OrderItem> OrderItems { get; set; }
        Task<int> SaveChanges();
    }
}
