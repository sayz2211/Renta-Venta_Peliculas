using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Formatos_PeliculasController : ControllerBase
    {
        private IFormatos_Peliculas_Negocio iFormatos_Peliculas;

        public Formatos_PeliculasController()
        {
            this.iFormatos_Peliculas = new Formatos_Peliculas_Negocio();
        }

        [HttpGet]
        public List<Formatos_Peliculas> ConsultarFormatosPeliculas()
        {
            if (this.iFormatos_Peliculas == null) throw new Exception("No implementado");
            return this.iFormatos_Peliculas.Consultar();
        }

        [HttpPost]
        public Formatos_Peliculas GuardarFormatoPelicula([FromBody] Formatos_Peliculas entidad)
        {
            if (this.iFormatos_Peliculas == null) throw new Exception("No implementado");
            return this.iFormatos_Peliculas.Guardar(entidad);
        }

        [HttpPut]
        public Formatos_Peliculas ModificarFormatoPelicula([FromBody] Formatos_Peliculas entidad)
        {
            if (this.iFormatos_Peliculas == null) throw new Exception("No implementado");
            return this.iFormatos_Peliculas.Modificar(entidad);
        }
    }
}
