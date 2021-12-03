using DataAccess.Interfaces;
using DataAccess.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Configuration;
using WebApplication.Data;
using WebApplication.Services;

namespace WebApplication
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<AppSettings>(Configuration.GetSection("ConnectionStrings"));


            services.AddTransient<IUnitOfWork, SqlServerConnection>();
            services.AddTransient<IServiceCatalogo, ServiceCatalogo>();
            services.AddTransient<IServiceAlmacen, ServiceAlmacen>();
            services.AddTransient<IServiceColor, ServiceColor>();
            services.AddTransient<IServiceMarca, ServiceMarca>();
            services.AddTransient<IServiceProducto, ServiceProducto>();
            services.AddTransient<IServiceProveedor, ServiceProveedor>();
            services.AddTransient<IServicesSubCategoria, ServicesSubCategoria>();
            services.AddTransient<IServiceTalla, ServiceTalla>();
            services.AddTransient<IServiceCompra, ServiceCompra>();
            services.AddTransient<IServiceVenta, ServiceVenta>();
            services.AddTransient<IServiceUsuario, ServiceUsuario>();

            services.AddRazorPages();
            services.AddControllers();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
