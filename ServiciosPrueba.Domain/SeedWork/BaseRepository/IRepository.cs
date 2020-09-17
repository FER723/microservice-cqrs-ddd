using ServicioPrueba.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioPrueba.Domain.SeedWork
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(int id);

        T GetSingleBySpec(ISpecification<T> spec);

        IEnumerable<T> ListAll();

        IEnumerable<T> List(ISpecification<T> spec);

        T Add(T entity);

        IEnumerable<T> Add(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(T entity);

    }
}
