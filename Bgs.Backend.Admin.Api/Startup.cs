using Bgs.Bll;
using Bgs.Bll.Abstract;
using Bgs.Dal;
using Bgs.Dal.Abstract;
using Bgs.Infrastructure.Api.Authorization;
using Bgs.Infrastructure.Api.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bgs.Backend.Admin.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            // services
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IInternalUserService, InternalUserService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<ITransactionService, TransactionService>();
            services.AddSingleton<IOrderService, OrderService>();

            // repositories
            services.AddSingleton<IInternalUserRepository, InternalUserRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<ITransactionRepository, TransactionRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<ICartRepository, CartRepository>();


            services.AddHttpClient();

            services.AddControllers();
            services.AddBgsAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}