using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStorProject.Models;
using BookStorProject.Models.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookStorProject
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddScoped<IBookStorRepository<Author>, AuthorDbRepository > ();
            services.AddScoped<IBookStorRepository<Book>, BookDbRepository>();
            services.AddDbContext<BookStoreDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("SqlCon"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();
            app.UseMvc(route => {
                route.MapRoute("default", "{controller=Book}/{action=Index}/{id?}");
            });
        }
    }
}
