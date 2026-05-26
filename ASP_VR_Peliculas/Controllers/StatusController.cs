using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StatusController : ControllerBase
    {
        private IStatus_Negocio iStatus;

        public StatusController()
        {
            this.iStatus = new Status_Negocio();
        }

        [HttpGet]
        public List<Status> ConsultarStatus()
        {
            if (this.iStatus == null) throw new Exception("No implementado");
            return this.iStatus.Consultar();
        }

        [HttpPost]
        public Status GuardarStatus([FromBody] Status entidad)
        {
            if (this.iStatus == null) throw new Exception("No implementado");
            return this.iStatus.Guardar(entidad);
        }
    }
}
