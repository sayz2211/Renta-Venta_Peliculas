using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReclamosController : ControllerBase
    {
        private IReclamos_Negocio iReclamos;

        public ReclamosController()
        {
            this.iReclamos = new Reclamos_Negocio();
        }

        [HttpGet]
        public List<Reclamos> ConsultarReclamos()
        {
            if (this.iReclamos == null) throw new Exception("No implementado");
            return this.iReclamos.Consultar();
        }

        [HttpPost]
        public Reclamos GuardarReclamo([FromBody] Reclamos entidad)
        {
            if (this.iReclamos == null) throw new Exception("No implementado");
            return this.iReclamos.Guardar(entidad);
        }
    }
}
