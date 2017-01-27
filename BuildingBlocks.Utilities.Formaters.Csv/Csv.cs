using System;
using System.Reflection;

namespace BuildingBlocks.Utilities.Formaters.Csv
{
    /// <summary>
    /// Using reflection to build up the strings.
    /// </summary>
    public class Csv : ICsv
    {
        public string ToCsvHeader(object obj)
        {
            var result = string.Empty;
            Array.ForEach(GetProperties(obj), prop =>
            {
                result += prop.Name + ",";
            });

            return (!string.IsNullOrEmpty(result) ? result.Substring(0, result.Length - 1) : result);
        }

        public string ToCsvRow(object obj)
        {
            var result = string.Empty;
            Array.ForEach(GetProperties(obj), prop =>
            {
                var value = prop.GetValue(obj, null);
                var propertyType = prop.PropertyType.FullName;
                if (propertyType == "System.String")
                {
                    value = "\"" + value + "\"";
                }

                result += value + ",";

            });

            return (!string.IsNullOrEmpty(result) ? result.Substring(0, result.Length - 1) : result);
        }

        private static PropertyInfo[] GetProperties(object obj)
        {
            var type = obj.GetType();
            return type.GetProperties(BindingFlags.DeclaredOnly |
                                           BindingFlags.Public |
                                           BindingFlags.Instance);
        }
    }
}
