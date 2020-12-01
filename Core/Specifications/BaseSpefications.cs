using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpefications<T> : ISpecifications<T>
    {
        public BaseSpefications()
        {
        }

        public BaseSpefications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> includes { get; } 
                    = new List<Expression<Func<T, object>>>();
        
        protected void AddIncluds(Expression<Func<T,object>> Expression)
        {
            includes.Add(Expression);
        }

    }
}