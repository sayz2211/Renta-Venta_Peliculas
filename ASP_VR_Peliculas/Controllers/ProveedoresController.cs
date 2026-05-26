using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProveedoresController : ControllerBase
    {
        private IProveedores_Negocio iProveedores;

        public ProveedoresController()
        {
            this.iProveedores = new Proveedores_Negocio();
        }

        [HttpGet]
        public List<Proveedores> ConsultarProveedores()
        {
            if (this.iProveedores == null) throw new Exception("No implementado");
            return this.iProveedores.Consultar();
        }

        [HttpPost]
        public Proveedores GuardarProveedor([FromBody] Proveedores entidad)
        {
            if (this.iProveedores == null) throw new Exception("No implementado");
            return this.iProveedores.Guardar(entidad);
        }

        [HttpPut]
        public Proveedores ModificarProveedor([FromBody] Proveedores entidad)
        {
            if (this.iProveedores == null) throw new Exception("No implementado");
            return this.iProveedores.Modificar(entidad);
        }

        [HttpDelete]
        public Proveedores EliminarProveedor([FromBody] Proveedores entidad)
        {
            if (this.iProveedores == null) throw new Exception("No implementado");
            return this.iProveedores.Eliminar(entidad);
        }
    }
}
