using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using ComicWeb.Core;
using ComicWeb.JsonService;
using System.IO;

namespace ComicWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();

            //configure DI
            services.AddSingleton(typeof(IStoryService), typeof(StoryService));
            services.AddSingleton(typeof(IUserService), typeof(UserService));
            //services.AddTransient.AddSingleton(typeof(IStoryService), typeof(StoryService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            IUserService service = new UserService();
            var hostingEnvironment = app.ApplicationServices.GetService<IHostingEnvironment>();
            var realPath = hostingEnvironment.WebRootPath;// + ctx.Request.Path.Value;

            service.SetDataFolder(realPath +"\\app_data");
            //app.Use(async (ctx, next) =>
            //{
            //    var hostingEnvironment = app.ApplicationServices.GetService<IHostingEnvironment>();
            //    var realPath = hostingEnvironment.WebRootPath + ctx.Request.Path.Value;

            //    // so something with the file here

            //    await next();
            //});

            app.UseIISPlatformHandler();

            //app.UseIISPlatformHandler();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
            //app.UseMiddleware<StaticFileMiddleware>(new StaticFileOptions());

            app.Run(context =>
            {
                /* if (context.Request.Path.Value != "/app")
                 {
                     context.Response.Redirect("/");
                 };
                 */
                hostingEnvironment = app.ApplicationServices.GetService<IHostingEnvironment>();
                realPath = hostingEnvironment.WebRootPath;// + ctx.Request.Path.Value;

                var indexFile = Path.Combine(realPath, "index.html");

                context.Response.ContentType = "text/html";
                context.Response.WriteAsync(File.ReadAllText(indexFile));
                return Task.FromResult<object>(null);
            });

        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
