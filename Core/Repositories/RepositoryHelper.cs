using System.Linq.Expressions;
using System.Reflection;
using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;

namespace StandardizedFilters.Core.Services.Request;
public class RepositoryHelper<TEntity>: IRepositoryHelper<TEntity> where TEntity : class
{
    public RepositoryHelper() {
    }

    public IQueryable<TEntity> ApplyFilters(IQueryable<TEntity> query, RequestFilter[]? filters) {
        if (filters is null || filters.Length == 0)
            return query;
            
        foreach (RequestFilter filter in filters) {
            if(filter.Field == "PasswordHash")
                throw new ArgumentException("No, just no...");

            switch (filter.Operation.ToUpper()) {
                case "EQ":
                    query = query.Where(this.BuildEqualPredicate(filter));
                    break;
                case "LIKE":
                    query = query.Where(this.BuildLikePredicate(filter));
                    break;
                // TODO implement other operators
                default:
                    throw new ArgumentException("Filter operator not recognized");
            }
        }
        // TODO implement sorting, pagination
        return query;
    }

    private Expression<Func<TEntity, bool>> BuildEqualPredicate(RequestFilter filter) {
        ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity), "x");

        MemberExpression fieldExpression = Expression.Property(parameterExpression, filter.Field);
        Expression valueExpression = Expression.Constant(filter.Value);

        if (fieldExpression.Type == typeof(int)) {
            if (!int.TryParse(filter.Value, out int intValue))
                throw new ArgumentException("Il valore del filtro non è un intero valido.");
                
            valueExpression = Expression.Constant(intValue);
        }

        return Expression.Lambda<Func<TEntity, bool>>(
            Expression.Equal(fieldExpression, valueExpression), parameterExpression);
    }

    private Expression<Func<TEntity, bool>> BuildLikePredicate(RequestFilter filter) {
        ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity), "x");

        MemberExpression fieldExpression = Expression.Property(parameterExpression, filter.Field);
        ConstantExpression valueExpression = Expression.Constant(filter.Value);

        MethodInfo? toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);

        MethodCallExpression propertyToLowerExpr = Expression.Call(fieldExpression, toLowerMethod!);
        MethodCallExpression valueToLowerExpr = Expression.Call(valueExpression, toLowerMethod!);
        
        MethodInfo? containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

        MethodCallExpression containsExpr = Expression.Call(propertyToLowerExpr, containsMethod!, valueToLowerExpr);

        return Expression.Lambda<Func<TEntity, bool>>(containsExpr, parameterExpression);
    }
}