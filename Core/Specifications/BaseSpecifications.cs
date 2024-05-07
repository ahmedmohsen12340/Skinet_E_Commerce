using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Helpers;

namespace Core.Specifications
{
    public class BaseSpecifications<T> : ISpecification<T>
    {
        private int? pageSize;
        private int? pageIndex;

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; protected set; }

        public Order OrderByType { get; protected set; } = Order.Asc;

        public int? PageSize
        {
            get => pageSize;
            protected set
            {
                if (value > 50 || value < 3)
                    pageSize = 6;
                else
                    pageSize = value;
            }
        }

        public int? PageIndex
        {
            get => pageIndex;
            protected set
            {
                if (value < 0)
                    pageIndex = 1;
                else
                    pageIndex = value;
            }
        }

        public bool IsPagingEnabled { get; protected set; } = true;

        public BaseSpecifications(Expression<Func<T, bool>> criteria = null)
        {
            Criteria = criteria;
        }
        public void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }
    }
}