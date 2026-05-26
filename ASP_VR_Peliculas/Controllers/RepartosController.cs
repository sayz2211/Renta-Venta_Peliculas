using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RepartosController : ControllerBase
    {
        private IRepartos_Negocio iRepartos;

        public RepartosController()
        {
            this.iRepartos = new Repartos_Negocio();
        }

        [HttpGet]
        public List<Repartos> ConsultarRepartos()
        {
            if (this.iRepartos == null) throw new Exception("No implementado");
            return this.iRepartos.Consultar();
        }

        [HttpPost]
        public Repartos GuardarReparto([FromBody] Repartos entidad)
        {
            if (this.iRepartos == null) throw new Exception("No implementado");
            return this.iRepartos.Guardar(entidad);
        }
    }
}
