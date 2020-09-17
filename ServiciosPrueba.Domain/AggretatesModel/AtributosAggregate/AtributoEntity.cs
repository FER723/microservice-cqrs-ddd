using ServicioPrueba.Domain.SeedWork;
using ServicioPrueba.Domain.Events.Atributos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioPrueba.Domain.Atributo
{
    public class AtributoEntity : Entity, IAggregateRoot
    {

        public int atributoId { get; }
        public string descripcion { get; set; }


        public AtributoEntity()
        {
            // Only for EF.
        }

        public AtributoEntity(int id, string descripcion)
        {
            this.atributoId = id > 0 ? id : throw new ArgumentNullException(nameof(id));
            this.descripcion = !string.IsNullOrWhiteSpace(descripcion) ? descripcion : throw new ArgumentNullException(nameof(descripcion));

            //Add domain Event
            this.AddDomainEvent(new AtributoCreatedEvent(this.atributoId, this.descripcion));
        }

        public static AtributoEntity CreateNew(int id, string descripcion)
        {
            return new AtributoEntity(id, descripcion);
        }

    }
}
