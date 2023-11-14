using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Quartz.Redis.Store
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var att = enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>();

            return att?.Name ?? string.Empty;
        }
    }
}
