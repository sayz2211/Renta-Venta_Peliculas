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
        public IActionResult GuardarProveedor(Proveedores entidad)
        {
            try { return Ok(iProveedores.Guardar(entidad)); }
            catch (Exception ex) { return BadRequest(new { mensaje = ex.Message }); }
        }

        [HttpPut]
        public IActionResult ModificarProveedor(Proveedores entidad)
        {
            try { return Ok(iProveedores.Modificar(entidad)); }
            catch (Exception ex) { return BadRequest(new { mensaje = ex.Message }); }
        }

        [HttpDelete]
        public IActionResult EliminarProveedor(Proveedores entidad)
        {
            try { return Ok(iProveedores.Eliminar(entidad)); }
            catch (Exception ex) { return BadRequest(new { mensaje = ex.Message }); }
        }
    }
}
