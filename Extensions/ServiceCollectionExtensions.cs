using ProvaPub.Interface;
using ProvaPub.Services;

namespace ProvaPub.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<RandomService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<ProductService>();
            services.AddScoped<OrderService>();

            services.AddScoped<IPaymentService, PaymentCreditCard>();
            services.AddScoped<IPaymentService, PaymentPaypal>();
            services.AddScoped<IPaymentService, PaymentPix>();
                        
            return services;
        }
    }
}
