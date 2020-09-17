using MediatR;
using ServicioPrueba.Application.Atributos.GetAtributos;

namespace ServicioPrueba.Application.Atributos.AddAtributos
{
    public class AtributosAddCommand : IRequest<AtributoDto>
    {
        public int AtributoId { get; }

        public string Descripcion { get;  }

        public AtributosAddCommand(int id, string descripcion)
        {
            this.AtributoId = id;
            this.Descripcion = descripcion;
        }
    }
}
