using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Rentas_PeliculasController : ControllerBase
    {
        private IRentas_Peliculas_Negocio iRentas_Peliculas;

        public Rentas_PeliculasController()
        {
            this.iRentas_Peliculas = new Rentas_Peliculas_Negocio();
        }

        [HttpGet]
        public List<Rentas_Peliculas> ConsultarRentasPeliculas()
        {
            if (this.iRentas_Peliculas == null) throw new Exception("No implementado");
            return this.iRentas_Peliculas.Consultar();
        }

        [HttpPost]
        public Rentas_Peliculas GuardarRentaPelicula([FromBody] Rentas_Peliculas entidad)
        {
            if (this.iRentas_Peliculas == null) throw new Exception("No implementado");
            return this.iRentas_Peliculas.Guardar(entidad);
        }
    }
}
