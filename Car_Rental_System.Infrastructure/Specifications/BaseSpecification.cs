using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Car_Rental_System.Infrastructure.Specifications.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Car_Rental_System.Infrastructure.Specifications;


public class BaseSpecification<T> : ISpecifications<T> where T : BaseEntity
{
    public BaseSpecification()
    {

    }

    public BaseSpecification(Expression<Func<T, bool>> whereCriteria)
    {
        WhereCriteria = whereCriteria;
    }

    protected virtual void AddNestedInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> nestedIncludeExpression)
    {
        NestedIncludes.Add(nestedIncludeExpression);
    }
    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        IncludesCriteria.Add(includeExpression);
    }
    public void ApplyPagination(int skip, int take)
    {
        IsPaginationEnabled = true;
        Skip = skip;
        Take = take;
    }
}
