using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private IUsuarios_Negocio iUsuarios;

        public UsuariosController()
        {
            this.iUsuarios = new Usuarios_Negocio();
        }

        [HttpGet]
        public List<Usuarios> ConsultarUsuarios()
        {
            if (this.iUsuarios == null) throw new Exception("No implementado");
            return this.iUsuarios.Consultar();
        }

        [HttpPost]
        public Usuarios GuardarUsuario([FromBody] Usuarios entidad)
        {
            if (this.iUsuarios == null) throw new Exception("No implementado");
            return this.iUsuarios.Guardar(entidad);
        }

        [HttpPut]
        public Usuarios ModificarUsuario([FromBody] Usuarios entidad)
        {
            if (this.iUsuarios == null) throw new Exception("No implementado");
            return this.iUsuarios.Modificar(entidad);
        }

        [HttpDelete]
        public Usuarios EliminarUsuario([FromBody] Usuarios entidad)
        {
            if (this.iUsuarios == null) throw new Exception("No implementado");
            return this.iUsuarios.Eliminar(entidad);
        }
    }
}
