using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDbToolkit.Annotations
{
    public class TableName : Attribute
    {
        public string Name { get; set; }

        public TableName(string name)
        {
            Name = name;
        }
    }
}
