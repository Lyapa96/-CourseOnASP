using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstHomework
{
    public class Startup
    {
        private const int HardWorkInMilliseconds = 2000;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<StopwatchMiddleware>();

            app.Use(async (contex, next) =>
            {
                var stopwath = new Stopwatch();
                stopwath.Start();

                await next.Invoke();

                await contex.Response.WriteAsync($"(Use)Time of request processing: {stopwath.ElapsedMilliseconds}");
            });

            app.Use((contex, next) => Task.Delay(HardWorkInMilliseconds));
        }
    }

    public class StopwatchMiddleware
    {
        private const int MiddlewareHardWorkInMilliseconds = 1000;
        private readonly RequestDelegate next;

        public StopwatchMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var stopwath = new Stopwatch();
            stopwath.Start();

            await next.Invoke(httpContext);
            await Task.Delay(MiddlewareHardWorkInMilliseconds);

            await httpContext.Response.WriteAsync($"\r\n(UseMiddleware)Time of request processing: {stopwath.ElapsedMilliseconds}");
        }
    }
}
