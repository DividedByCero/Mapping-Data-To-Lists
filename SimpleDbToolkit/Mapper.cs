using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SimpleDbToolkit
{
    public class Mapper
    {
        /// <summary>
        /// Get a Collection of List<T> Objects from a ConnectionObject based in a SQL Statement"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="DbConnection">The Connection Object</param>
        /// <param name="Statement">The SQL Sentences prompt to be fetch into the collection.</param>
        /// <returns>List<Object></returns>
        public static List<T> Get<T>(System.Data.IDbConnection DbConnection, string Statement) where T : class, new()
        {
            IDbCommand dbCommand = DbConnection.CreateCommand();
            dbCommand.CommandText = Statement;
            DbConnection.Open();
            //get properties of the base class;
            IList<System.Reflection.PropertyInfo> ClassStruct = new T().GetType().GetProperties().ToList();
            IDataReader Reader = dbCommand.ExecuteReader();
            IEnumerable<string> Columns = Reader.GetSchemaTable().Select().Select(x => x[0].ToString());
            List<T> ListOfObjectsToReturn = new List<T>();

            while (Reader.Read())
            {
                T instance = new T();
                for (int ctd = 0; ctd < ClassStruct.Count(); ctd++)
                {
                    object value = Reader.GetValue(Reader.GetOrdinal(ClassStruct[ctd].Name));
                    ClassStruct.First(property => property.Name == ClassStruct[ctd].Name)
                        .SetValue(instance, (value.GetType() == typeof(DBNull) ? null : value), null);
                }
                ListOfObjectsToReturn.Add(instance);
            }

            DbConnection.Close();

            return ListOfObjectsToReturn;
        }

        public static List<T> Get<T>(System.Data.IDbConnection DbConnection, string Statement, out TimeSpan executionTime) where T : class, new()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            List<T> result = Get<T>(DbConnection, Statement);
            watch.Stop();
            executionTime = watch.Elapsed;
            return result;
        }
    }
}
