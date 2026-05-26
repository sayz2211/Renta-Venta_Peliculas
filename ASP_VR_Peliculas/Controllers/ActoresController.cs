using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ActoresController : ControllerBase
    {
        private IActores_Negocio iActores;

        public ActoresController()
        {
            this.iActores = new Actores_Negocio();
        }

        [HttpGet]
        public List<Actores> ConsultarActores()
        {
            if (this.iActores == null) throw new Exception("No implementado");
            return this.iActores.Consultar();
        }

        [HttpPost]
        public Actores GuardarActor([FromBody] Actores entidad)
        {
            if (this.iActores == null) throw new Exception("No implementado");
            return this.iActores.Guardar(entidad);
        }

        [HttpPut]
        public Actores ModificarActor([FromBody] Actores entidad)
        {
            if (this.iActores == null) throw new Exception("No implementado");
            return this.iActores.Modificar(entidad);
        }

        [HttpDelete]
        public Actores EliminarActor([FromBody] Actores entidad)
        {
            if (this.iActores == null) throw new Exception("No implementado");
            return this.iActores.Eliminar(entidad);
        }
    }
}
