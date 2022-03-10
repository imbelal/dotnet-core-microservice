using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Interfaces;
using Order.Persistence.Context;

namespace Order.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("OrderDbConnection"),
                    b => b.MigrationsAssembly(typeof(OrderDbContext).Assembly.FullName)));
            services.AddScoped<IOrderDbContext>(provider => provider.GetService<OrderDbContext>());
        }
    }
}
