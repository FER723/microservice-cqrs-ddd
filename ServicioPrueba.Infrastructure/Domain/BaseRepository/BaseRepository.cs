using Microsoft.EntityFrameworkCore;
using ServicioPrueba.Domain.SeedWork;
using ServicioPrueba.Domain.Specification;
using ServicioPrueba.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioPrueba.Infrastructure.Domain.BaseRepository
{
    public class BaseRepository<T> : IRepository<T>, IAsyncRepository<T> where T : Entity
    {
        protected readonly BDContext _context;

        public BaseRepository(BDContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }


        #region Sincrono
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public IEnumerable<T> Add(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return entities;
        }

       
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

      
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return List(spec).FirstOrDefault();
        }

        public IEnumerable<T> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                            .Where(spec.Criteria)
                            .AsEnumerable();
        }

        public IEnumerable<T> ListAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }


        #endregion



        #region Asincrono

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                            .Where(spec.Criteria)
                            .ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }


        #endregion

    }
}
