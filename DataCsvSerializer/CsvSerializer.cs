using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataCsvSerializer
{
    public class CsvSerializer
    {
        public static string Serialize<T>(T obj)
        {
            var sb = new StringBuilder();
            var type = typeof(T);
            // Для использования public и private полей
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var value = field.GetValue(obj);
                sb.Append(value?.ToString() + ",");
            }

            return sb.ToString().TrimEnd(',');
        }

        public static T Deserialize<T>(string csv) where T : new()
        {
            var values = csv.Split(',');
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var obj = new T();

            for (int i = 0; i < fields.Length; i++)
            {
                var fieldType = fields[i].FieldType;
                var value = Convert.ChangeType(values[i], fieldType);
                fields[i].SetValue(obj, value);
            }

            return obj;
        }
    }
}
