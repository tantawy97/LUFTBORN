using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text;

namespace Infrastructure.Persistence.Extensions
{
    public static class AuditLogExtension
    {
        internal static string GetChanges(EntityEntry entity)
        {
            var changes = new StringBuilder();
            foreach (var property in entity.OriginalValues.Properties)
            {
                var originalValue = entity.OriginalValues[property];
                var currentValue = entity.CurrentValues[property];
                if (!Equals(originalValue, currentValue))
                {
                    changes.AppendLine($"{property.Name}: From '{originalValue}' to '{currentValue}'");
                }
            }
            return changes.ToString();
        }
    }
}
