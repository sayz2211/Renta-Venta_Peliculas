using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SucursalesController : ControllerBase
    {
        private ISucursales_Negocio iSucursales;

        public SucursalesController()
        {
            this.iSucursales = new Sucursales_Negocio();
        }

        [HttpGet]
        public List<Sucursales> ConsultarSucursales()
        {
            if (this.iSucursales == null) throw new Exception("No implementado");
            return this.iSucursales.Consultar();
        }

        [HttpPost]
        public Sucursales GuardarSucursal([FromBody] Sucursales entidad)
        {
            if (this.iSucursales == null) throw new Exception("No implementado");
            return this.iSucursales.Guardar(entidad);
        }

        [HttpPut]
        public Sucursales ModificarSucursal([FromBody] Sucursales entidad)
        {
            if (this.iSucursales == null) throw new Exception("No implementado");
            return this.iSucursales.Modificar(entidad);
        }

        [HttpDelete]
        public Sucursales EliminarSucursal([FromBody] Sucursales entidad)
        {
            if (this.iSucursales == null) throw new Exception("No implementado");
            return this.iSucursales.Eliminar(entidad);
        }
    }
}
