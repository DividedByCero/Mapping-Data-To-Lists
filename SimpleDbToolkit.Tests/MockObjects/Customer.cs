using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleDbToolkit.Annotations;
namespace SimpleDbToolkit.Tests.MockObjects
{
    [TableName("CUSTOMERS")]
    public class Customer
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreditNumber { get; set; }
        public long Identification { get; set; }
        public string LastName { get; set; }
    }
}
