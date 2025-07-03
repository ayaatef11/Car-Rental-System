using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Car_Rental_System.Infrastructure.Specifications;

public class SpecificationsEvaluator<T> where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> spec)
    {
        var query = inputQuery;

        if (spec.WhereCriteria != null)
            query = query.Where(spec.WhereCriteria);

        query = spec.IncludesCriteria.Aggregate(query,
  (current, include) => current.Include(include));

        foreach (var include in spec.ThenIncludes)
        {
            query = query.Include(include);
        }

        if (spec.OrderBy != null)
            query = query.OrderBy(spec.OrderBy);

        else if (spec.OrderByDesc != null)
            query = query.OrderByDescending(spec.OrderByDesc);

        if (spec.IsPaginationEnabled)
            query = query.Skip(spec.Skip).Take(spec.Take);

        query = spec.IncludesCriteria.Aggregate(query, (currentQuery, includeExpression) =>
        currentQuery.Include(includeExpression));

        if (spec.IncludeExpressions != null && spec.IncludeExpressions.Any())
        {
            query = spec.IncludeExpressions.Aggregate(query, (currentQuery, includeExpression) =>
                includeExpression(currentQuery));
        }
        return query;
    }

}


