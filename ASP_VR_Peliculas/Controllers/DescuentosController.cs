using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DescuentosController : ControllerBase
    {
        private IDescuentos_Negocio iDescuentos;

        public DescuentosController()
        {
            this.iDescuentos = new Descuentos_Negocio();
        }

        [HttpGet]
        public List<Descuentos> ConsultarDescuentos()
        {
            if (this.iDescuentos == null) throw new Exception("No implementado");
            return this.iDescuentos.Consultar();
        }

        [HttpPost]
        public Descuentos GuardarDescuento([FromBody] Descuentos entidad)
        {
            if (this.iDescuentos == null) throw new Exception("No implementado");
            return this.iDescuentos.Guardar(entidad);
        }

        [HttpPut]
        public Descuentos ModificarDescuento([FromBody] Descuentos entidad)
        {
            if (this.iDescuentos == null) throw new Exception("No implementado");
            return this.iDescuentos.Modificar(entidad);
        }
    }
}
