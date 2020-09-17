using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServicioPrueba.Domain.Atributo;
using ServicioPrueba.Domain.SeedWork;
using ServicioPrueba.Domain.Specification;
using ServicioPrueba.Infrastructure.Database;
using ServicioPrueba.Infrastructure.Domain.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioPrueba.Infrastructure.Domain.Atributo
{
    class AtributoRepository : BaseRepository<AtributoEntity>, IAtributosRepository
    {
       
        public AtributoRepository(BDContext context) : base(context)
        {
            
        }

        async Task IAtributosRepository.AddAsync(AtributoEntity atributo)
        {
            await this._context.Atributo.AddAsync(atributo);
        }

        AtributoEntity IAtributosRepository.GetElement(ISpecification<AtributoEntity> specification)
        {
            return this._context.Atributo.Where(specification.Criteria).FirstOrDefault();
        }

        AtributoEntity IAtributosRepository.ModifyAsync(AtributoEntity atributo)
        {
            EntityEntry<AtributoEntity> update = this._context.Atributo.Update(atributo);
            return update.Entity;
        }

        void IAtributosRepository.RemoveAsync(AtributoEntity atributo)
        {
            this._context.Remove(atributo);
        }
    }
}
