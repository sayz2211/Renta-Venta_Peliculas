using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DevolucionesController : ControllerBase
    {
        private IDevoluciones_Negocio iDevoluciones;

        public DevolucionesController()
        {
            this.iDevoluciones = new Devoluciones_Negocio();
        }

        [HttpGet]
        public List<Devoluciones> ConsultarDevoluciones()
        {
            if (this.iDevoluciones == null) throw new Exception("No implementado");
            return this.iDevoluciones.Consultar();
        }

        [HttpPost]
        public Devoluciones GuardarDevolucion([FromBody] Devoluciones entidad)
        {
            if (this.iDevoluciones == null) throw new Exception("No implementado");
            return this.iDevoluciones.Guardar(entidad);
        }
    }
}
