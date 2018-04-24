using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleDbToolkit.Annotations;
using System.Reflection;

namespace SimpleDbToolkit
{
    public class QueryConstructor<T> where T : class, new()
    {
        private string ResolveColumnValue(object value)
        {
            if (value == null)
                return "null";

            if (value.GetType() == typeof(string))
            {
                return "'" + value.ToString() + "'";
            }
            else
            {
                return value.ToString();
            }
        }

        private bool validateCustomAttribute<Y>(System.Reflection.PropertyInfo prop) where Y : Attribute
        {
            return prop.GetCustomAttributes(typeof(Y), false).Count() == 0;
        }

        public string Insert(T item)
        {
            var type = item.GetType();
            var properties = type.GetProperties().Where(prop =>
            {
                return validateCustomAttribute<AutoIncrement>(prop);
            });

            StringBuilder builder = new StringBuilder("INSERT INTO ");
            object TableNameAttribute = type.GetCustomAttributes(typeof(TableName), false).FirstOrDefault();
            string tablename = TableNameAttribute == null ? type.Name : ((TableName)TableNameAttribute).Name;

            builder.Append(string.Format("{0}({1})", tablename, String.Join(", ", properties.Select(prop => prop.Name))));
            IEnumerable<string> values = properties.Select(x =>
            {
                return ResolveColumnValue(x.GetValue(item));
            });

            builder.Append(string.Format(" VALUES({0});", string.Join(", ", values.ToArray())));
            return builder.ToString();
        }

        public string SelectAll() 
        {
            Type sample = new T().GetType();
            PropertyInfo[] props = sample.GetProperties();
            var statement = new string[props.Count() + 3];
            statement[0] = "SELECT";
            int x = 1;

            foreach(var prop in props)
            {
                statement[x] = prop.Name + ",";
                x++;
            }

            statement[x++] = "FROM";
            statement[x++] = sample.Name;

            return string.Join(" ", statement);
        }
    }
}
