using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DirectoresController : ControllerBase
    {
        private IDirectores_Negocio iDirectores;

        public DirectoresController()
        {
            this.iDirectores = new Directores_Negocio();
        }

        [HttpGet]
        public List<Directores> ConsultarDirectores()
        {
            if (this.iDirectores == null) throw new Exception("No implementado");
            return this.iDirectores.Consultar();
        }

        [HttpPost]
        public Directores GuardarDirector([FromBody] Directores entidad)
        {
            if (this.iDirectores == null) throw new Exception("No implementado");
            return this.iDirectores.Guardar(entidad);
        }

        [HttpPut]
        public Directores ModificarDirector([FromBody] Directores entidad)
        {
            if (this.iDirectores == null) throw new Exception("No implementado");
            return this.iDirectores.Modificar(entidad);
        }

        [HttpDelete]
        public Directores EliminarDirector([FromBody] Directores entidad)
        {
            if (this.iDirectores == null) throw new Exception("No implementado");
            return this.iDirectores.Eliminar(entidad);
        }
    }
}
