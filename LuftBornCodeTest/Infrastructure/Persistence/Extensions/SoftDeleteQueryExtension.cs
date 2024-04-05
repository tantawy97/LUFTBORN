using Core.Audit.Interface;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System.Reflection;

namespace Infrastructure.Persistence.Extensions
{
    public static class SoftDeleteQueryExtension
    {
        public static void AddSoftDeleteQueryFilter(this IMutableEntityType entityData)
        {
            var methodToCall = typeof(SoftDeleteQueryExtension)
                .GetMethod(nameof(GetSoftDeleteFilter),
                BindingFlags.NonPublic | BindingFlags.Static)?
                .MakeGenericMethod(entityData.ClrType);
            var filter = methodToCall?.Invoke(null, []);
            entityData.SetQueryFilter((LambdaExpression)filter!);
            entityData.AddIndex(entityData.FindProperty(nameof(ISoftDeletedEntity.IsDeleted))!);
        }

        private static Expression<Func<TEntity, bool>> GetSoftDeleteFilter<TEntity>() where TEntity : ISoftDeletedEntity
        {
            Expression<Func<TEntity, bool>> filter = x => !x.IsDeleted;
            return filter;
        }
    }
}
