using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VP_Peliculas.Entidades
{
    public class Status
    {
        public int Id { get; set; }
        public bool status { get; set; }
        public List<Clientes>? Clientes { get; set; }
        public List<Empleados>? Empleados { get; set; }
    }
}
