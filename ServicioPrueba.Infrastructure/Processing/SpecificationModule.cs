using System.Reflection;
using Autofac;
using MediatR;
using ServicioPrueba.Domain.Atributo;
using ServicioPrueba.Infrastructure.Specification;

namespace ServicioPrueba.Infrastructure.Processing
{ 
    public class SpecificationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AtributoSpecification>()
                 .As<IAtributosSpecification>()
                .InstancePerLifetimeScope();
        }
    }
}