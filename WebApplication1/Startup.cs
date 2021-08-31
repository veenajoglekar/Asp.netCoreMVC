using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //}
            // When the environment is not in development phase then the default browser error is shown
            // instead of the detailed exception page.


            // Run method cannot call next middleware, This will be used to end the pipeline registrations
            // and acts as a final step.
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello!My First Middleware!");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello!My second Middleware!");
            //});
            //output: Hello!My First Middleware!



            //Use : This is used to allow the request delegate to pass the request to the next middleware in the pipeline.
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello!My First Middleware! \n");
            //    await next();
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello!My second Middleware!");
            //    await next();
            //});
            //output: Hello!My First Middleware! 
            //Hello!My second Middleware!




            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello!My First Middleware! \n");
            //    await next();
            //    await context.Response.WriteAsync("Hello!My First Middleware! \n");

            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello!My second Middleware!\n");
            //    await next();
            //    await context.Response.WriteAsync("Hello!My second Middleware! \n");

            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello!Run method called \n");
            //});
            //output : Hello!My First Middleware! 
            //Hello!My second Middleware!
            //Hello!Run method called
            //Hello!My second Middleware!
            //Hello!My First Middleware!



            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello!My First Middleware! \n");
            //    //await next();
            //    await context.Response.WriteAsync("Hello!My First Middleware! \n");

            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello!Run method called \n");
            //});
            //output:Hello!My First Middleware! 
            //Hello!My First Middleware!


            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello!My First Middleware!");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello!My second Middleware!");

            //});
            //output: Hello!My First Middleware!







            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    throw new Exception("Error Occurred while processing your request");
                    await context.Response.WriteAsync("Hello World!");
                    //await context.Response.WriteAsync("Worker Process Name : " + System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                });
                endpoints.MapGet("/info", async context =>
                {
                    await context.Response.WriteAsync("Hello World!,Info");
                    //await context.Response.WriteAsync("Worker Process Name : " + System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                });
            });
        }
    }
}
