using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FormatosController : ControllerBase
    {
        private IFormatos_Negocio iFormatos;

        public FormatosController()
        {
            this.iFormatos = new Formatos_Negocio();
        }

        [HttpGet]
        public List<Formatos> ConsultarFormatos()
        {
            if (this.iFormatos == null) throw new Exception("No implementado");
            return this.iFormatos.Consultar();
        }

        [HttpPost]
        public Formatos GuardarFormato([FromBody] Formatos entidad)
        {
            if (this.iFormatos == null) throw new Exception("No implementado");
            return this.iFormatos.Guardar(entidad);
        }

        [HttpPut]
        public Formatos ModificarFormato([FromBody] Formatos entidad)
        {
            if (this.iFormatos == null) throw new Exception("No implementado");
            return this.iFormatos.Modificar(entidad);
        }
    }
}
