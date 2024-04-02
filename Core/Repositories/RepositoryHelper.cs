using System.Linq.Expressions;
using System.Reflection;
using GamesAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

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
                

            ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity), "x");
            
            MemberExpression fieldExpression = Expression.Property(parameterExpression, filter.Field);
            ConstantExpression valueExpression = Expression.Constant(filter.Value);

            if (fieldExpression.Type == typeof(int)) {
                if (!int.TryParse(filter.Value, out int intValue))
                    throw new ArgumentException("Provided filter value is not an integer.");
                    
                valueExpression = Expression.Constant(intValue);
            }

            if (fieldExpression.Type == typeof(DateTime)) {
                if (!DateTime.TryParse(filter.Value, out DateTime dateTimeValue))
                    throw new ArgumentException("Provided filter value is not a valid date.");

                valueExpression = Expression.Constant(dateTimeValue);
            }

            switch(filter.Operation.ToUpper()) {
                case "EQ":
                    query = query.Where(this.BuildEqualPredicate(parameterExpression, fieldExpression, valueExpression));
                    break;
                case "NEQ":
                    query = query.Where(this.BuildNotEqualPredicate(parameterExpression, fieldExpression, valueExpression));
                    break;
                case "LIKE":
                    query = query.Where(this.BuildLikePredicate(parameterExpression, fieldExpression, valueExpression));
                    break;
                case "GT":
                    query = query.Where(this.BuildGreaterThanPredicate(parameterExpression, fieldExpression, valueExpression));
                    break;
                case "GTE":
                    query = query.Where(this.BuildGreaterThanOrEqualPredicate(parameterExpression, fieldExpression, valueExpression));
                    break;
                case "LT":
                    query = query.Where(this.BuildLowerThanPredicate(parameterExpression, fieldExpression, valueExpression));
                    break;
                case "LTE":
                    query = query.Where(this.BuildLowerThanOrEqualPredicate(parameterExpression, fieldExpression, valueExpression));
                    break;
                // TODO implement other operators
                default:
                    throw new ArgumentException("Filter operator not recognized");
            }
        }
        // TODO implement pagination
        return query;
    }

    public IQueryable<TEntity> ApplyOrder(IQueryable<TEntity> query, RequestOrder? order) {
        if (order is null)
            return query;

        if(order.Field is null || order.Direction is null)
            return query;

        string? field = char.ToUpper(order.Field[0]) + order.Field.Substring(1);

        switch (order.Direction.ToLower()){
            case OrderDirection.ASC:
                query = query.OrderBy(e => EF.Property<object>(e, field));
                break;
            case OrderDirection.DESC:
                query = query.OrderByDescending(e => EF.Property<object>(e, field));
                break;
            default:
                throw new ArgumentException("Order direction not recognized");
        }

        return query;
    }


    private Expression<Func<TEntity, bool>> BuildEqualPredicate(ParameterExpression parameterExpression, MemberExpression fieldExpression, ConstantExpression valueExpression) {
        return Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(fieldExpression, valueExpression), parameterExpression);
    }

    private Expression<Func<TEntity, bool>> BuildNotEqualPredicate(ParameterExpression parameterExpression, MemberExpression fieldExpression, ConstantExpression valueExpression) {
        return Expression.Lambda<Func<TEntity, bool>>(Expression.NotEqual(fieldExpression, valueExpression), parameterExpression);
    }

    private Expression<Func<TEntity, bool>> BuildGreaterThanPredicate(ParameterExpression parameterExpression, MemberExpression fieldExpression, ConstantExpression valueExpression) {
        return Expression.Lambda<Func<TEntity, bool>>(Expression.GreaterThan(fieldExpression, valueExpression), parameterExpression);
    }

    private Expression<Func<TEntity, bool>> BuildGreaterThanOrEqualPredicate(ParameterExpression parameterExpression, MemberExpression fieldExpression, ConstantExpression valueExpression) {
        return Expression.Lambda<Func<TEntity, bool>>(Expression.GreaterThanOrEqual(fieldExpression, valueExpression), parameterExpression);
    }

    private Expression<Func<TEntity, bool>> BuildLowerThanPredicate(ParameterExpression parameterExpression, MemberExpression fieldExpression, ConstantExpression valueExpression) {
        return Expression.Lambda<Func<TEntity, bool>>(Expression.LessThan(fieldExpression, valueExpression), parameterExpression);
    }

    private Expression<Func<TEntity, bool>> BuildLowerThanOrEqualPredicate(ParameterExpression parameterExpression, MemberExpression fieldExpression, ConstantExpression valueExpression) {
        return Expression.Lambda<Func<TEntity, bool>>(Expression.LessThanOrEqual(fieldExpression, valueExpression), parameterExpression);
    }

    private Expression<Func<TEntity, bool>> BuildLikePredicate(ParameterExpression parameterExpression, MemberExpression fieldExpression, ConstantExpression valueExpression) {
        if(fieldExpression.Type != typeof(string))
            throw new ArgumentException("Provided LIKE filter field is not a string.");

        MethodInfo? toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);

        MethodCallExpression propertyToLowerExpr = Expression.Call(fieldExpression, toLowerMethod!);
        MethodCallExpression valueToLowerExpr = Expression.Call(valueExpression, toLowerMethod!);
        
        MethodInfo? containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

        MethodCallExpression containsExpr = Expression.Call(propertyToLowerExpr, containsMethod!, valueToLowerExpr);

        return Expression.Lambda<Func<TEntity, bool>>(containsExpr, parameterExpression);
    }
}