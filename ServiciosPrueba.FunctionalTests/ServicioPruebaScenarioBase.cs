using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using System;

namespace ServicioPrueba.FunctionalTests
{
    public class ServicioPruebaScenarioBase
    {
        public IHostBuilder CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(ServicioPruebaScenarioBase))
                .Location;

            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();
                   
                    webHost.Configure(app => app.Run(async ctx =>
                    await ctx.Response.WriteAsync("Hello World!")));
                });

            // Build and start the IHost
            //var host = await hostBuilder.StartAsync();
            //testServer.Host
            //    .MigrateDbContext<OrderingContext>((context, services) =>
            //    {
            //        var env = services.GetService<IHostingEnvironment>();
            //        var settings = services.GetService<IOptions<OrderingSettings>>();
            //        var logger = services.GetService<ILogger<OrderingContextSeed>>();

            //        new OrderingContextSeed()
            //            .SeedAsync(context, env, settings, logger)
            //            .Wait();
            //    })
            //    .MigrateDbContext<IntegrationEventLogContext>((_, __) => { });

            return hostBuilder;
        }

        public IHostBuilder CreateServerIntegration()
        {
            IHostBuilder host = new HostBuilder();

            try
            {
                host = Host.CreateDefaultBuilder()
                    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                     .ConfigureWebHostDefaults(webBuilder =>
                     {
                         webBuilder.UseTestServer();
                         webBuilder.UseStartup<Startup>();
                     });

            }
            catch (Exception e)
            {
                throw e;
            }

            return host;
        }

        public IHostBuilder CreateServerFunctional()
        {
            IHostBuilder host = new HostBuilder();

            try
            {
                host = Host.CreateDefaultBuilder()
                     .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                     .ConfigureWebHostDefaults(webBuilder =>
                     {
                         webBuilder.UseTestServer();
                         webBuilder.UseStartup<Startup>();
                     });

            }catch(Exception e)
            {
                throw e;
            }

            return host;
        }
             

        public static class Get
        {
            public static string Atributos = "/atributos";

            public static string AtributosBAD = "/atributos1";

            public static string AtributosBy(int id)
            {
                return $"/atributos/{id}";
            }
        }

        public static class Put
        {
            //public static string CancelOrder = "api/v1/orders/cancel";
            //public static string ShipOrder = "api/v1/orders/ship";
        }
    }
}
