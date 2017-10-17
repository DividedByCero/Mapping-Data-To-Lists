using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DbReflectLib
{
    public class Mapper
    {
        /// <summary>
        /// Get a Collection of List<T> Objects from a ConnectionObject based in a SQL Statement"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="DbConnection">The Connection Object</param>
        /// <param name="Statement">The SQL Sentences prompt to be fetch into the collection.</param>
        /// <returns></returns>
        public static List<T> Get<T>(System.Data.IDbConnection DbConnection, string Statement) where T : class, new()
        {
            IDbCommand dbCommand = DbConnection.CreateCommand();
            DbConnection.Open();
            dbCommand.CommandText = Statement;
            //Instance to be compare with the especific model.
            Type BaseInstance = new T().GetType();
            //Getting the properties;
            System.Reflection.PropertyInfo[] ClassStruct = BaseInstance.GetProperties();
            IDataReader Reader = dbCommand.ExecuteReader();
            List<string> Columns = new List<string>();
            List<T> ListOfObjectsToReturn = new List<T>();
            foreach (DataRow item in Reader.GetSchemaTable().Rows)
            {
                Columns.Add(item[0].ToString());
            }

            while (Reader.Read())
            {
                T instance = new T();
                for (int ctd = 0; ctd < Columns.Count; ctd++)
                {
                    Console.WriteLine(Reader.GetValue(ctd).ToString());
                    object value = Reader.GetValue(ctd);
                    ClassStruct.First(property => property.Name == Columns[ctd])
                        .SetValue(instance, (value.GetType() == typeof(DBNull) ? null : value), null);
                }
                ListOfObjectsToReturn.Add(instance);
            }

            return ListOfObjectsToReturn;
        }

    }
}
