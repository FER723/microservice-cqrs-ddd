using ServicioPrueba.Domain.SeedWork;
using ServicioPrueba.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicioPrueba.Domain.SeedWork
{
    public interface IAsyncRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id);

        Task<List<T>> ListAllAsync();

        Task<List<T>> ListAsync(ISpecification<T> spec);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
