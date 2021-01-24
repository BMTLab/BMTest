using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace BMTest.Server
{
    public class Startup
    {
        #region Ctor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion _Ctors


        #region Properties
        public IConfiguration Configuration { get; }
        #endregion _Properties


        #region Methods
        public static void ConfigureServices(IServiceCollection services)
        {
            #region Cors
            services.AddCors();
            #endregion _Cors


            services.AddControllers();
            services.AddSwaggerGen
            (
                c =>
                {
                    c.SwaggerDoc
                    (
                        "v1",
                        new OpenApiInfo
                        {
                            Title = "Server",
                            Version = "v1"
                        }
                    );
                }
            );
        }


        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server v1"));
            }
            else
            {
                app.UseStatusCodePages();
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors
            (
                options =>
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                }
            );

            app.UseAuthorization();

            app.MapWhen
            (
                ctx => !ctx.Request.Path.StartsWithSegments(@"/api", StringComparison.CurrentCultureIgnoreCase),
                _ =>
                {
                    app.UseEndpoints
                    (
                        endpoints => { endpoints.MapFallbackToFile(@"index.html"); }
                    );
                }
            );

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        #endregion _Methods
    }
}