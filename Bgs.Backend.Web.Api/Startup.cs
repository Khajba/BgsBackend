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

namespace Bgs.Backend.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            //Services

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IMultimediaService, FileSystemMultimediaService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<IWishListService, WishListService>();
            services.AddSingleton<ICartService, CartService>();
            // repositories
            
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IWishListRepository, WishListRepository>();
            services.AddSingleton<ICartRepository, CartRepository>();
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
