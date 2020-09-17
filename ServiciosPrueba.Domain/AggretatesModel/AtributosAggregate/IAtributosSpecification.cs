using ServicioPrueba.Domain.Specification;
using System.Threading.Tasks;

namespace ServicioPrueba.Domain.Atributo
{
    public interface IAtributosSpecification
    {
        ISpecification<AtributoEntity> GetAtributoById(int atributoId);
    }
}
