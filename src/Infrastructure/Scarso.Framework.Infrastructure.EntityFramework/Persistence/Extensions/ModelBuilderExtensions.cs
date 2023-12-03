using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Scarso.Framework.Domain.Entities.Interfaces;
using Scarso.Framework.Domain.Persistence.Attributes;
using System.Linq.Expressions;
using System.Reflection;

namespace Scarso.Framework.Infrastructure.EntityFramework.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyGlobalFilters<TInterface>(this ModelBuilder modelBuilder, Expression<Func<TInterface, bool>> expression)
    {
        var entities = modelBuilder.Model
           .GetEntityTypes()
           .Where(e => e.ClrType.GetInterface(typeof(TInterface).Name) != null)
           .Select(e => e.ClrType);

        foreach (var entity in entities)
        {
            var newParam = Expression.Parameter(entity);
            var newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);

            modelBuilder.Entity(entity)
                .HasQueryFilter(Expression.Lambda(newbody, newParam));
        }
    }

    public static ModelBuilder ApplyAutoSeeding(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        var entityTypesWithAutoSeededProperties = assemblies.SelectMany(assembly => assembly.GetTypes()
            .Where(x => x.IsClass && x.GetInterface(nameof(IEntity)) != null)
            .SelectMany(e => e.GetProperties())
            .Where(e => e.GetCustomAttribute<AutoSeedAttribute>() != null)
            .GroupBy(e => e.DeclaringType!)).ToList();

        entityTypesWithAutoSeededProperties
            .ForEach(e =>
            {
                var entityType = modelBuilder.Entity(e.Key);
                e.ToList().ForEach(x => entityType.HasData(x.GetValue(x) ?? throw new NullReferenceException()));
            });

        return modelBuilder;
    }
}
