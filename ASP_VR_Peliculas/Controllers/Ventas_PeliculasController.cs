using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ventas_PeliculasController : ControllerBase
    {
        private IVentas_Peliculas_Negocio iVentas_Peliculas;

        public Ventas_PeliculasController()
        {
            this.iVentas_Peliculas = new Ventas_Peliculas_Negocio();
        }

        [HttpGet]
        public List<Ventas_Peliculas> ConsultarVentasPeliculas()
        {
            if (this.iVentas_Peliculas == null) throw new Exception("No implementado");
            return this.iVentas_Peliculas.Consultar();
        }

        [HttpPost]
        public Ventas_Peliculas GuardarVentaPelicula([FromBody] Ventas_Peliculas entidad)
        {
            if (this.iVentas_Peliculas == null) throw new Exception("No implementado");
            return this.iVentas_Peliculas.Guardar(entidad);
        }
    }
}
