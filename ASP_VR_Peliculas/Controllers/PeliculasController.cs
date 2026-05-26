using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PeliculasController : ControllerBase
    {
        private IPeliculas_Negocio iPeliculas;

        public PeliculasController()
        {
            this.iPeliculas = new Peliculas_Negocio();
        }

        [HttpGet]
        public List<Peliculas> ConsultarPeliculas()
        {
            if (this.iPeliculas == null) throw new Exception("No implementado");
            return this.iPeliculas.Consultar();
        }

        [HttpPost]
        public Peliculas GuardarPelicula([FromBody] Peliculas entidad)
        {
            if (this.iPeliculas == null) throw new Exception("No implementado");
            return this.iPeliculas.Guardar(entidad);
        }

        [HttpPut]
        public Peliculas ModificarPelicula([FromBody] Peliculas entidad)
        {
            if (this.iPeliculas == null) throw new Exception("No implementado");
            return this.iPeliculas.Modificar(entidad);
        }

        [HttpDelete]
        public Peliculas EliminarPelicula([FromBody] Peliculas entidad)
        {
            if (this.iPeliculas == null) throw new Exception("No implementado");
            return this.iPeliculas.Eliminar(entidad);
        }
    }
}
