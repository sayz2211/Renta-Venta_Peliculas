using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MembresiasController : ControllerBase
    {
        private IMembresias_Negocio iMembresias;

        public MembresiasController()
        {
            this.iMembresias = new Membresias_Negocio();
        }

        [HttpGet]
        public List<Membresias> ConsultarMembresias()
        {
            if (this.iMembresias == null) throw new Exception("No implementado");
            return this.iMembresias.Consultar();
        }

        [HttpPost]
        public Membresias GuardarMembresia([FromBody] Membresias entidad)
        {
            if (this.iMembresias == null) throw new Exception("No implementado");
            return this.iMembresias.Guardar(entidad);
        }

        [HttpPut]
        public Membresias ModificarMembresia([FromBody] Membresias entidad)
        {
            if (this.iMembresias == null) throw new Exception("No implementado");
            return this.iMembresias.Modificar(entidad);
        }
    }
}
