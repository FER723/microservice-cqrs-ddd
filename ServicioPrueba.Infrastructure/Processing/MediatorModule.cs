using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Autofac.Features.Variance;
using MediatR;
using MediatR.Pipeline;
using FluentValidation;
using ServicioPrueba.Application.Atributos.GetAtributos;
using ServicioPrueba.Application.Configuration.Validation;
using ServicioPrueba.Application.Atributos.AddAtributos;

namespace ServicioPrueba.Infrastructure.Processing
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(INotificationHandler<>),
                typeof(IValidator<>),
            };


            /* Aquí es donde "ocurre la magia" con MediatR.
             * Como cada controlador de comandos implementa la interfaz genérica al registrar los ensamblados, el código registra con RegisteredAssemblyTypes todos los tipos marcados 
             * como IRequestHandler o INotificationHandler o IValidator
             * https://docs.microsoft.com/es-es/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/microservice-application-layer-implementation-web-api
             */
            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(GetAtributosQuery).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterGeneric(typeof(CommandValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
