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
<<<<<<< HEAD
<<<<<<< HEAD
            string ConnectionString = "";
=======
            string ConnectionString = "Data Source=.;Initial Catalog=Enterprise;Integrated Security=True";
>>>>>>> 67a0cbc... create Benchmark proj for testing cases.
=======
            string ConnectionString = "";
>>>>>>> 2156183... delete duplicate benchmark project
            SqlConnection Conn = new SqlConnection(ConnectionString);
            TimeSpan executionTime = new TimeSpan();
            
            List<Supplier> Suppliers =  Mapper.Get<Supplier>(Conn, "SELECT * FROM Suppl", out executionTime);

            Console.WriteLine(executionTime);
            Console.ReadKey();
        }
    }
}
