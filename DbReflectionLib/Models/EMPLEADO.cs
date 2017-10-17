using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbReflectionLib.Models
{
    public class EMPLOYEE
    {
        public int EMP_NO { get; set; }
        public string APELLIDO { get; set; }
        public string OFICIO { get; set; }
        public int? DIRECTOR { get; set; }
        public DateTime FECHA_ALTA { get; set; }
        public double? SALARIO { get; set; }
        public double? COMISION { get; set; }
        public int? DEP_NO { get; set; }
    }
}
