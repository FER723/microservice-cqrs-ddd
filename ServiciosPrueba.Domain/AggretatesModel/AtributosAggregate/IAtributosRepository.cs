using ServicioPrueba.Domain.Specification;
using System.Threading.Tasks;

namespace ServicioPrueba.Domain.Atributo
{
    public interface IAtributosRepository 
    {
        AtributoEntity GetElement(ISpecification<AtributoEntity> specification);

        Task AddAsync(AtributoEntity atributo);
        
        void RemoveAsync(AtributoEntity atributo);

        AtributoEntity ModifyAsync(AtributoEntity atributo);
    }
}
