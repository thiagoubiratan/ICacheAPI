using ICache.Api.Extensions;
using ICache.Core.Context;
using ICache.Core.Interfaces.Repositories;
using ICache.Core.Interfaces.UoW;
using ICache.Repository.Repositories;
using ICache.Repository.Uow;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace ICache.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ICacheContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ICache"),
                x => x.MigrationsAssembly("ICache.Core")));

            services.AddCors(o =>
            {
                o.AddPolicy("default", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("ICacheApi", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "ICache API", Version = "1.0" });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(b =>
            {
                b.Run(async context =>
                {
                    var corsService = context.RequestServices.GetService<ICorsService>();
                    var corsPolicyProvider = context.RequestServices.GetService<ICorsPolicyProvider>();
                    var corsPolicy = await corsPolicyProvider.GetPolicyAsync(context, "default");
                    corsService.ApplyResult(corsService.EvaluatePolicy(context, corsPolicy), context.Response);
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                    if (null != exceptionObject)
                    {
                        var errorMessage = $"<b>Error: {exceptionObject.Error.Message}</ b > { exceptionObject.Error.StackTrace}                        ";
                        await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
                    }
                });
            });

            app.UseCors("default");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCustomExceptionMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/ICacheApi/swagger.json", "ICacheApi");
                options.RoutePrefix = "";
            });
        }
    }
}
