using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace SimpleDbToolkit
{
    public static class QueryConstructor<T> where T : class, new()
    {
        public static string SelectAll() 
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
