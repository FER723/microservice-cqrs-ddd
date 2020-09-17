using System.Collections.Generic;
using MediatR;

namespace ServicioPrueba.Application.Atributos.GetAtributos
{
    public class GetAtributosQuery : IRequest<List<AtributoDto>>
    {
        public int atributoID { get; }

        public GetAtributosQuery()
        {
        }

        public GetAtributosQuery(int id)
        {
            atributoID = id;
        }
    }
}