using Autofac;
using ServicioPrueba.Infrastructure.Database;
using ServicioPrueba.Infrastructure.Processing;
using ServicioPrueba.Infrastructure.Service;

namespace ServicioPrueba.Infrastructure
{
    public class ApplicationStartup
    {
        public static void Initialize(
           ContainerBuilder container,
            string connectionString,
            string connectionKrakenString)
        {
            container.RegisterModule(new DataAccessModule(connectionString));
            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new ProcessingModule());
            container.RegisterModule(new SpecificationModule());
            container.RegisterModule(new KrakenAccessModule(connectionKrakenString));
        }
    }
}