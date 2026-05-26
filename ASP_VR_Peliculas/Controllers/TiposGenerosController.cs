using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TiposGenerosController : ControllerBase
    {
        private ITiposGeneros_Negocio iTiposGeneros;

        public TiposGenerosController()
        {
            this.iTiposGeneros = new TiposGeneros_Negocio();
        }

        [HttpGet]
        public List<TiposGeneros> ConsultarTiposGeneros()
        {
            if (this.iTiposGeneros == null) throw new Exception("No implementado");
            return this.iTiposGeneros.Consultar();
        }

        [HttpPost]
        public TiposGeneros GuardarTipoGenero([FromBody] TiposGeneros entidad)
        {
            if (this.iTiposGeneros == null) throw new Exception("No implementado");
            return this.iTiposGeneros.Guardar(entidad);
        }

        [HttpPut]
        public TiposGeneros ModificarTipoGenero([FromBody] TiposGeneros entidad)
        {
            if (this.iTiposGeneros == null) throw new Exception("No implementado");
            return this.iTiposGeneros.Modificar(entidad);
        }
    }
}
