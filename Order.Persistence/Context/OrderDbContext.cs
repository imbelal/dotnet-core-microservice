using Microsoft.EntityFrameworkCore;
using Order.Application.Interfaces;
using System.Threading.Tasks;

namespace Order.Persistence.Context
{
    public class OrderDbContext : DbContext, IOrderDbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
       : base(options)
        {
        }
        public DbSet<Order.Domain.Entities.Order> Orders { get; set; }
        public DbSet<Order.Domain.Entities.OrderItem> OrderItems { get; set; }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
