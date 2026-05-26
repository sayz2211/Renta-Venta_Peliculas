using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private IRoles_Negocio iRoles;

        public RolesController()
        {
            this.iRoles = new Roles_Negocio();
        }

        [HttpGet]
        public List<Roles> ConsultarRoles()
        {
            if (this.iRoles == null) throw new Exception("No implementado");
            return this.iRoles.Consultar();
        }

        [HttpPost]
        public Roles GuardarRol([FromBody] Roles entidad)
        {
            if (this.iRoles == null) throw new Exception("No implementado");
            return this.iRoles.Guardar(entidad);
        }

        [HttpPut]
        public Roles ModificarRol([FromBody] Roles entidad)
        {
            if (this.iRoles == null) throw new Exception("No implementado");
            return this.iRoles.Modificar(entidad);
        }
    }
}
