using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacturasController : ControllerBase
    {
        private IFacturas_Negocio iFacturas;

        public FacturasController()
        {
            this.iFacturas = new Facturas_Negocio();
        }

        [HttpGet]
        public List<Facturas> ConsultarFacturas()
        {
            if (this.iFacturas == null) throw new Exception("No implementado");
            return this.iFacturas.Consultar();
        }

        [HttpPost]
        public Facturas GuardarFactura([FromBody] Facturas entidad)
        {
            if (this.iFacturas == null) throw new Exception("No implementado");
            return this.iFacturas.Guardar(entidad);
        }
    }
}
