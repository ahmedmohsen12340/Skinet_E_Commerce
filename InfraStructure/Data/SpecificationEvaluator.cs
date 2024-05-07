using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Helpers;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Data
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static int Count;
        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery, ISpecification<T> spec)
        {
            var query = InputQuery;
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            if (spec.OrderBy != null)
            {
                if (spec.OrderByType == Order.Desc)
                {
                    query = query.OrderByDescending(spec.OrderBy);
                }
                else
                {
                    query = query.OrderBy(spec.OrderBy);
                }
            }
            Count = query.Count();
            if (spec.IsPagingEnabled)
            {
                query = query.Skip((spec.PageIndex.Value - 1) * spec.PageSize.Value).Take(spec.PageSize.Value);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}