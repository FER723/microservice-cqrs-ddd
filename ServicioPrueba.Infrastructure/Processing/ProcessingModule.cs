using System.Reflection;
using Autofac;
using MediatR;

namespace ServicioPrueba.Infrastructure.Processing
{ 
    public class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DomainEventsDispatcher>()
                .As<IDomainEventsDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}