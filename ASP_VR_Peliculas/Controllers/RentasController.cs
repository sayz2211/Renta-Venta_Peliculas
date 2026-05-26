using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RentasController : ControllerBase
    {
        private IRentas_Negocio iRentas;

        public RentasController()
        {
            this.iRentas = new Rentas_Negocio();
        }

        [HttpGet]
        public List<Rentas> ConsultarRentas()
        {
            if (this.iRentas == null) throw new Exception("No implementado");
            return this.iRentas.Consultar();
        }

        [HttpPost]
        public Rentas GuardarRenta([FromBody] Rentas entidad)
        {
            if (this.iRentas == null) throw new Exception("No implementado");
            return this.iRentas.Guardar(entidad);
        }
    }
}
