using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WebApplication01.Services;

namespace WebApplication01
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

            _ = services.AddControllersWithViews(); // isto é um serviço

            //services.AddSingleton<IService, MyServiceClass>(); genericamente service -> Interface c# implementado pela class IMyClassService indicada na Class MyClassService
            _ = services.AddSingleton<IMyClassService, MyClassService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }
            else
            {
                _ = app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                _ = app.UseHsts();
            }

            #region Custom MiddleWare

            // using RUN - > nao corre os seguintes, run corre logo
            /*
            app.Run(async (context) => {
                await context.Response.WriteAsync("Texto do middleWare WITH RUN");
            });
            */

            /// Ao usar estes middlewares nao funciona o rooteamento para os controladores. devido ao Response.WriteAsync
            // using USE -> apenas corre no final, podemos ter vários
            /*
            _ = app.Use(async (context, next) => {
                await context.Response.WriteAsync($"Texto do middleWare 1{Environment.NewLine}");
                await next.Invoke();
            });

            _ = app.Use(async (context, next) => {
                await context.Response.WriteAsync($"Texto do middleWare 2{Environment.NewLine}");
                await next.Invoke();
            });

            _ = app.Use(async (context, next) => {
                await context.Response.WriteAsync($"Texto do middleWare 3{Environment.NewLine}");
                await next.Invoke();
            });

            _ = app.Use(async (context, next) => {
                await context.Response.WriteAsync($"Texto do middleWare 4{Environment.NewLine}");
                await next.Invoke();
            });
            */
            #endregion

            /// middleWare já disponivel por defeito 
            _ = app.UseHttpsRedirection();
            
            /// middleware que permite o uso da pasta wwwroot com ficheiros estaticos -> css, js, html, images, etc
            _ = app.UseStaticFiles();

            /// middleware que verificará o enderço
            _ = app.UseRouting();

            /// middleWare que trabalhará a Autorização da App ou do Site
            _ = app.UseAuthorization();

            /// middleWare que usára um enderço default
            _ = app.UseEndpoints(aEndpoints => {
                _ = aEndpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
