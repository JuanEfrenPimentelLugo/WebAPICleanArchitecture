using Microsoft.Extensions.DependencyInjection;
using Enterprice.Solution.Application.Interface.UseCases;
using Enterprice.Solution.Application.UseCases.Categories;
using Enterprice.Solution.Application.UseCases.Customers;
using Enterprice.Solution.Application.UseCases.Discounts;
using Enterprice.Solution.Application.UseCases.Users;
using Enterprice.Solution.Application.Validator;
using System.Reflection;

namespace Enterprice.Solution.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<ICategoriesApplication, CategoriesApplication>();
            services.AddScoped<IDiscountsApplication, DiscountsApplication>();

            services.AddTransient<UsersDtoValidator>();
            services.AddTransient<DiscountDtoValidator>();

            return services;
        }
    }
}
