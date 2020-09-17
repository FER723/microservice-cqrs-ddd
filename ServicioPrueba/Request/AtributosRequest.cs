using MediatR;
using ServicioPrueba.Application.Atributos.GetAtributos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ervicioPrueba.API.Request
{
    public class AtributosRequest
    {
        public int AtributoId { get; set; }

        public string Descripcion { get; set; }
    }
}
