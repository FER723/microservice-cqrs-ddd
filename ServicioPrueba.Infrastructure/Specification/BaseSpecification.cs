using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using ServicioPrueba.Domain.Specification;

namespace ServicioPrueba.Infrastructure.Specification
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {

        public Expression<Func<T, bool>> Criteria { get; internal set; }
        
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public List<string> IncludeStrings { get; } = new List<string>();


        public void SetCriteria(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
    }
}
