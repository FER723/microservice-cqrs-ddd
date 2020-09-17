using Autofac;
using ServicioPrueba.Application.Configuration.Data;
using ServicioPrueba.Domain.Atributo;
using ServicioPrueba.Domain.SeedWork;
using ServicioPrueba.Infrastructure.Domain;
using ServicioPrueba.Infrastructure.Domain.Atributo;

namespace ServicioPrueba.Infrastructure.Database
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly string _databaseConnectionString;

        public DataAccessModule(string databaseConnectionString)
        {
            this._databaseConnectionString = databaseConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _databaseConnectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AtributoRepository>()
                .As<IAtributosRepository>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<ProductRepository>()
            //    .As<IProductRepository>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<PaymentRepository>()
            //    .As<IPaymentRepository>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<StronglyTypedIdValueConverterSelector>()
            //    .As<IValueConverterSelector>()
            //    .InstancePerLifetimeScope();
        }
    }
}