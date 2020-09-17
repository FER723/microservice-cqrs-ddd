using MediatR;
using ServicioPrueba.Domain.Atributo;
using ServicioPrueba.Domain.Events.Atributos;
using ServicioPrueba.Domain.SeedWork;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioPrueba.Application.DomainEvent
{
    public class AtributoCreatedEventHandler : INotificationHandler<AtributoCreatedEvent>
    {

        private readonly IAtributosRepository _atributosRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAtributosSpecification _specification;

        public AtributoCreatedEventHandler(IAtributosRepository atributosRepository, IUnitOfWork unitOfWork, IAtributosSpecification specification)
        {
            _atributosRepository = atributosRepository;
            _unitOfWork = unitOfWork;
            _specification = specification;
        }

        /*
         * Ejemplo no real, pero para estructura not bad
         */
        async Task INotificationHandler<AtributoCreatedEvent>.Handle(AtributoCreatedEvent notification, CancellationToken cancellationToken)
        {
            AtributoEntity atributoExist = this._atributosRepository.GetElement(_specification.GetAtributoById(notification.AtributoId));

            if (atributoExist == null)
            {              

            }
        }
    }
}
