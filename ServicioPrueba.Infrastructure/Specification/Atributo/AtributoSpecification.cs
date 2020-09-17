
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ServicioPrueba.Domain.Atributo;
using ServicioPrueba.Domain.Specification;

namespace ServicioPrueba.Infrastructure.Specification
{
    public class AtributoSpecification : BaseSpecification<AtributoEntity>, IAtributosSpecification
    {

        ISpecification<AtributoEntity> IAtributosSpecification.GetAtributoById(int atributoId)
        {
            var spec = new AtributoSpecification();

            spec.SetCriteria(a => a.atributoId == atributoId);

            return spec;
        }
    }
}
