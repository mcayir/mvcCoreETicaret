using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using mvcCoreETicaret.Northwind.Business.Concrete;
using mvcCoreETicaret.Northwind.Entities.Concrete;
using mvcCoreETicaret.Northwind.Business.Abstract;
using mvcCoreETicaret.Northwind.DataAccess.Concrete.EntityFramework;
using mvcCoreETicaret.Northwind.DataAccess.Abstract;
using mvcCoreETicaret.Northwind.MvcWebUI.Middlewares;
using Microsoft.Extensions.Logging;
using mvcCoreETicaret.Northwind.MvcWebUI.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using mvcCoreETicaret.Northwind.MvcWebUI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace mvcCoreETicaret.Northwind.MvcWebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService,ProductManeger>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManeger>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddSingleton<ICartService,CartService>();
            services.AddSingleton<HttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<CustomIdentityDbContext>(options=>options.UseSqlServer(@"Data Source=DESKTOP-7GB2ORJ;Initial Catalog=NORTHWND;Integrated Security=True"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();
            services.AddMvc();
            services.AddSession();
            services.AddDistributedMemoryCache();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
       
            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath);
            app.UseIdentity();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
        }
    }
}
