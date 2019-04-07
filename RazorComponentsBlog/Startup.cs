using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blazor.FileReader;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using RazorComponentsBlog.Components;
using RazorComponentsBlog.Data;
using RazorComponentsBlog.Models;
using RazorComponentsBlog.Services;
using Sotsera.Blazor.Toaster.Core.Models;

namespace RazorComponentsBlog
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Env { get;  }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddNewtonsoftJson();
            services.AddRazorComponents();
            services.AddScoped<ArticleService>();
            services.AddScoped<IFileReaderService, FileReaderService>();
            services.AddDirectoryBrowser();
            services.AddToaster(config =>
            {
                config.PositionClass = Defaults.Classes.Position.TopRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.MaximumOpacity = 95;
            });

            SqlConnectionStringBuilder builder;
            if (Env.IsDevelopment())
            {
                builder = new SqlConnectionStringBuilder(
                        Configuration.GetConnectionString("RazorComponentsBlog_db"))
                    { Password = Configuration["RazorComponentsBlogDbPassword"] };
            }
            else
            {
                builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("RazorComponentsBlog_db"));
            }


            services.AddDbContext<RazorComponentsBlogDbContext>(options =>
                options.UseSqlServer(builder.ConnectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting(routes =>
            {
                routes.MapRazorPages();
                routes.MapComponentHub<App>("app");
            });
        }
    }
}
