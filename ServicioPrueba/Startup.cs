
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServicioPrueba.Infrastructure.Database;
using ServicioPrueba.API.Configuration;
using Hellang.Middleware.ProblemDetails;
using ServicioPrueba.Infrastructure;
using System;
using Autofac;
using System.Reflection;
using ServicioPrueba.Application.Configuration.Validation;
using ServicioPrueba.API.SeedWork;
using ServicioPrueba.Domain.SeedWork;

namespace ServicioPrueba
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private const string OrdersConnectionString = "OrdersConnectionString";
        private const string ConnectionKrakenString = "ConnectionKrakenString";

        public Startup(IWebHostEnvironment env)
        {
            //Configuration = configuration;
            this._configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                //.AddJsonFile($"hosting.{env.EnvironmentName}.json")
                .AddUserSecrets<Startup>()
                .Build();
        }

        public Startup(IConfiguration env)
        {
            this.Configuration = env;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerDocumentation();

            //services.AddCustomDbContext(Configuration);

            services.AddDbContext<BDContext>(options =>
             {
                 options.UseSqlServer(this._configuration[OrdersConnectionString],
                     sqlServerOptionsAction: sqlOptions =>
                     {
                         sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                     });
                 //options.UseSqlServer(this._configuration[OrdersConnectionString]);
             });

            services.AddProblemDetails(x =>
            {
                x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
            });

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac, like:
            ApplicationStartup.Initialize(
                builder,
                this._configuration[OrdersConnectionString],
                this._configuration[ConnectionKrakenString]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            app.UseSwaggerDocumentation();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }


        
    }

    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services
                   .AddDbContext<BDContext>(options =>
                   {
                       options.UseSqlServer(configuration["OrdersConnectionString"],
                           sqlServerOptionsAction: sqlOptions =>
                           {
                               //sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                               sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                           });
                   },
                       ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                   );
            return services;
        }
    }
}
