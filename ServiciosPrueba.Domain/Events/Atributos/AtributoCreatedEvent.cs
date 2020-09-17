using ServicioPrueba.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioPrueba.Domain.Events.Atributos
{
    public class AtributoCreatedEvent : DomainEventBase
    {
        public int AtributoId { get; }
        public string Descripcion { get;  }

        public AtributoCreatedEvent(int customerId, string descripcion)
        {
            this.AtributoId = customerId;
            this.Descripcion = descripcion;
        }
    }
}
