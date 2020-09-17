using MediatR;
using ServicioPrueba.Application.Atributos.GetAtributos;
using ServicioPrueba.Domain.SeedWork;
using ServicioPrueba.Domain.Atributo;
using System.Threading;
using System.Threading.Tasks;


namespace ServicioPrueba.Application.Atributos.AddAtributos
{
    public class AtributosAddCommandHandler : IRequestHandler<AtributosAddCommand, AtributoDto>
    {
        private readonly IAtributosRepository _atributosRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAtributosSpecification _specification;

        public AtributosAddCommandHandler(IAtributosRepository atributosRepository, IUnitOfWork unitOfWork, IAtributosSpecification specification)
        {
            _atributosRepository = atributosRepository;
            _unitOfWork = unitOfWork;
            _specification = specification;
        }

        public async Task<AtributoDto> Handle(AtributosAddCommand request, CancellationToken cancellationToken)
        {
 
            AtributoEntity atributo = AtributoEntity.CreateNew(request.AtributoId, request.Descripcion);

            AtributoEntity atributoExist = this._atributosRepository.GetElement(_specification.GetAtributoById(request.AtributoId));

            if (atributoExist == null)
            {
                await this._atributosRepository.AddAsync(atributo);

                await this._unitOfWork.CommitAsync(cancellationToken);

            }

            return new AtributoDto { idAtributo = atributo.atributoId, vchAtributo = atributo.descripcion };
        }
    }
}
