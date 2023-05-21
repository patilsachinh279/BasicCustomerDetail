using Microsoft.Extensions.DependencyInjection;
using Customer.Business.Data.DAL;
using Customer.Business.Data.Repository;

namespace Customer.Business.Data
{
    public static class DataRegistry
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IDataAccessLayer, DataAccessLayer>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
