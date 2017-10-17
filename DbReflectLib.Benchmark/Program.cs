using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DbReflectLib;
using DbReflectLib.Benchmark.Models;

namespace DbReflectLib.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = "Data Source=.;Initial Catalog=Enterprise;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(ConnectionString);
            TimeSpan executionTime = new TimeSpan();
            
            List<Supplier> Suppliers =  Mapper.Get<Supplier>(Conn, "SELECT * FROM Suppl", out executionTime);

            Console.WriteLine(executionTime);
            Console.ReadKey();
        }
    }
}
