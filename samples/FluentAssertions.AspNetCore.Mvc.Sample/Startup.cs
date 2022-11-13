using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
#if NETCOREAPP3_0_OR_GREATER
using Microsoft.Extensions.Hosting;
#endif

namespace FluentAssertions.AspNetCore.Mvc.Sample
{
    public class Startup
    {
        public Startup(
#if NETCOREAPP3_0_OR_GREATER
            IWebHostEnvironment env
#else
            IHostingEnvironment env
#endif
            )
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(options =>
            {
#if NETCOREAPP3_0
                options.EnableEndpointRouting = false;
#endif
            });

            services.AddLogging(configure =>
            {
                configure.AddConsole();
                configure.AddDebug();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
#if NETCOREAPP3_0_OR_GREATER
            IWebHostEnvironment env,
#else
            IHostingEnvironment env,
#endif
            ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
#if NETCOREAPP2_1
                app.UseBrowserLink();
#endif
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
#if NETCOREAPP2_1
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
#endif

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
