using MediatR;
using ServicioPrueba.Application.Atributos.GetAtributos;
using ServicioPrueba.Domain.SeedWork;
using ServicioPrueba.Domain.Atributo;
using System.Threading;
using System.Threading.Tasks;


namespace ServicioPrueba.Application.Atributos.AddAtributos
{
    public class AtributosModifyCommandHandler : IRequestHandler<AtributosModifyCommand, AtributoDto>
    {
        private readonly IAtributosRepository _atributosRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAtributosSpecification _specification;

        public AtributosModifyCommandHandler(IAtributosRepository atributosRepository, IUnitOfWork unitOfWork, IAtributosSpecification specification)
        {
            _atributosRepository = atributosRepository;
            _unitOfWork = unitOfWork;
            _specification = specification;
        }

        public async Task<AtributoDto> Handle(AtributosModifyCommand request, CancellationToken cancellationToken)
        {
            AtributoEntity atributo = new AtributoEntity();
            AtributoEntity atributoExist = this._atributosRepository.GetElement(_specification.GetAtributoById(request.AtributoId));

            if (atributoExist != null)
            {
                atributoExist.descripcion = request.Descripcion;
                atributo = this._atributosRepository.ModifyAsync(atributoExist);

                await this._unitOfWork.CommitAsync(cancellationToken);

            }

            return new AtributoDto { idAtributo = atributo.atributoId, vchAtributo = atributo.descripcion };
        }
    }
}
