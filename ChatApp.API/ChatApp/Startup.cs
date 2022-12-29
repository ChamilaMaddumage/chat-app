using ChatApp.Infrastructure.Data;
using ChatApp.Infrastructure.Extensions;
using ChatApp.WebAPI.Hubs;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace ChatApp
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
            services.AddControllers();

            string connectionString = Configuration.GetConnectionString("ChatAppConnectionString");

            services.AddDbContext<ChatAppContext>(options =>
            {
                options.UseSqlServer(connectionString);

            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders", builder =>
                {
                    builder.WithOrigins(Configuration.GetValue<string>("AllowOrigins")).AllowAnyHeader()
                        .AllowAnyMethod().AllowCredentials();
                });
            });

            services.AddScoped<IMediator, Mediator>();

            services.AddTransient<ServiceFactory>(sp => t => sp.GetService(t));

            services.AddMediatorHandler(AppDomain.CurrentDomain.Load("ChatApp.ApplicationCore"));

            services.AddServiceImplementation(AppDomain.CurrentDomain.Load("ChatApp.Infrastructure"));

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChatApp.WebAPI", Version = "v1" });
            });

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChatApp.WebAPI v1"));
            }

            app.UseCors("AllowAllHeaders");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatAppMessageHub>("/hubs");
            });
        }
    }
}
