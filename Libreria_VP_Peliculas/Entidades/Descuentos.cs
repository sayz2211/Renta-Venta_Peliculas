using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_VR_Peliculas.Entidades
{
    public class Descuentos
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public decimal Porcentaje { get; set; }
        public bool Activo { get; set; }
        public List<Facturas>? Facturas { get; set; }
    }
}
