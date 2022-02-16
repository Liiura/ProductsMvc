using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductsStore.Data.ContextDB;
using ProductsStore.Data.Mapper;

namespace ProductsStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNToastNotifyNoty(new NToastNotify.NotyOptions()
            {
                ProgressBar = true,
                Timeout = 3000,
                Theme = "mint"
            });
            var connectionStrings = Configuration["ConnectionStrings:Dev"];
            services.AddDbContext<ProductsContext>(o => o.UseLazyLoadingProxies().UseSqlServer(connectionStrings));

            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(Mappers));
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseNToastNotify();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            //app.UseMyMiddleware();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                   name: "AdminArea",
                   areaName: "Admin",
                   pattern: "Admin/{controller=Home}/{action=Index}"); //This is Administrator route. You can you {id} and other parameters which you want
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            });
        }
    }
}
