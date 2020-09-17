using MediatR;

namespace ServicioPrueba.Application.Atributos.AddAtributos
{
    public class AtributosDeleteCommand : IRequest<bool>
    {
        public int AtributoId { get; }
        public AtributosDeleteCommand(int id)
        {
            this.AtributoId = id;
        }
    }
}
