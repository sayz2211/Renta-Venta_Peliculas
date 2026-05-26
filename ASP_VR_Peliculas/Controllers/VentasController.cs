using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VentasController : ControllerBase
    {
        private IVentas_Negocio iVentas;

        public VentasController()
        {
            this.iVentas = new Ventas_Negocio();
        }

        [HttpGet]
        public List<Ventas> ConsultarVentas()
        {
            if (this.iVentas == null) throw new Exception("No implementado");
            return this.iVentas.Consultar();
        }

        [HttpPost]
        public Ventas GuardarVenta([FromBody] Ventas entidad)
        {
            if (this.iVentas == null) throw new Exception("No implementado");
            return this.iVentas.Guardar(entidad);
        }
    }
}
