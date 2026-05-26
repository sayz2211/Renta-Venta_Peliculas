using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InventariosController : ControllerBase
    {
        private IInventarios_Negocio iInventarios;

        public InventariosController()
        {
            this.iInventarios = new Inventarios_Negocio();
        }

        [HttpGet]
        public List<Inventarios> ConsultarInventarios()
        {
            if (this.iInventarios == null) throw new Exception("No implementado");
            return this.iInventarios.Consultar();
        }

        [HttpPost]
        public Inventarios GuardarInventario([FromBody] Inventarios entidad)
        {
            if (this.iInventarios == null) throw new Exception("No implementado");
            return this.iInventarios.Guardar(entidad);
        }

        [HttpPut]
        public Inventarios ModificarInventario([FromBody] Inventarios entidad)
        {
            if (this.iInventarios == null) throw new Exception("No implementado");
            return this.iInventarios.Modificar(entidad);
        }
    }
}
