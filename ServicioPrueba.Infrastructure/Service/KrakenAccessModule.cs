using Autofac;
using ServicioPrueba.Application.Configuration.Service;
using System.Net.Http;

namespace ServicioPrueba.Infrastructure.Service
{
    public class KrakenAccessModule : Autofac.Module
    {
        private readonly string _connectionString;

        public KrakenAccessModule(string _connectionString)
        {
            this._connectionString = _connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Kraken>()
                .As<IKraken>()
                .WithParameter("connectionString", _connectionString)
                .InstancePerLifetimeScope();
        }
    }
}