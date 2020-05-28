

using System.Threading.Tasks;
using Autofac;
using Dolittle.AspNetCore.Debugging;
using Dolittle.DependencyInversion.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Head2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDolittleSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseDolittleExecutionContext();
            app.UseDolittleSwagger();

            app.UseRouting();

            app.UseEndpoints(_ =>
                {
                    _.MapControllers();
                    _.MapDolittleApplicationModel();
                    _.MapGet("/", context =>
                        {
                            context.Response.Redirect("/swagger");
                            return Task.CompletedTask;
                        });
                });
        }
    }
}
