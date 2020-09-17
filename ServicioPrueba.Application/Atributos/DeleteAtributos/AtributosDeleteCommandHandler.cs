using MediatR;
using ServicioPrueba.Domain.SeedWork;
using ServicioPrueba.Domain.Atributo;
using System.Threading;
using System.Threading.Tasks;


namespace ServicioPrueba.Application.Atributos.AddAtributos
{
    public class AtributosDeleteCommandHandler : IRequestHandler<AtributosDeleteCommand, bool>
    {
        private readonly IAtributosRepository _atributosRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAtributosSpecification _specification;

        public AtributosDeleteCommandHandler(IAtributosRepository atributosRepository, IUnitOfWork unitOfWork, IAtributosSpecification specification)
        {
            _atributosRepository = atributosRepository;
            _unitOfWork = unitOfWork;
            _specification = specification;
        }

        public async Task<bool> Handle(AtributosDeleteCommand request, CancellationToken cancellationToken)
        {
            bool remove = false;
            AtributoEntity atributoExist = this._atributosRepository.GetElement(_specification.GetAtributoById(request.AtributoId));

            if (atributoExist != null)
            {
                _atributosRepository.RemoveAsync(atributoExist);
                remove = true;
            }
      
            await this._unitOfWork.CommitAsync(cancellationToken);
            return remove;
        }
    }
}
