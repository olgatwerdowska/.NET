using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Products.Models;
//using WebApplication.Extensions;
using WebApplication9.Models;
using Microsoft.AspNetCore.Identity;

namespace Products
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>() 
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage(); 
                app.UseStatusCodePages(); 
            } else { app.UseExceptionHandler("/Error"); }

            app.UseRouting();

            app.UseAuthentication();


            app.UseDeveloperExceptionPage(); // informacje szczegółowe o błędach
            app.UseStatusCodePages(); // Wyświetla strony ze statusem błędu
            app.UseStaticFiles(); // obsługa treści statycznych css, images, js
            app.UseRouting();
            //app.UseElapsedTimeMiddleware();

            app.UseAuthorization();

            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=List}/{id?}");

                routes.MapControllerRoute(
                    name: null,
                    pattern: "Product/{category}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List"
                    });
                routes.MapControllerRoute(
                    name: null,
                    pattern: "Admin/{action=Index}",
                    defaults: new
                    {
                        controller = "Admin"
                    });


            });

          SeedData.EnsurePopulated(app);


        }
    }
}
