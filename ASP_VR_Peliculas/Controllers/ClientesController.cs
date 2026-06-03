using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private IClientes_Negocio iClientes;

        public ClientesController()
        {
            this.iClientes = new Clientes_Negocio();
        }

        [HttpGet]
        public ActionResult<List<Clientes>> ConsultarClientes()
        {
            try
            {
                if (this.iClientes == null) throw new Exception("No implementado");
                return Ok(this.iClientes.Consultar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Clientes> GuardarCliente([FromBody] Clientes entidad)
        {
            try
            {
                if (this.iClientes == null) throw new Exception("No implementado");
                return Ok(this.iClientes.Guardar(entidad));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<Clientes> ModificarCliente([FromBody] Clientes entidad)
        {
            try
            {
                if (this.iClientes == null) throw new Exception("No implementado");
                return Ok(this.iClientes.Modificar(entidad));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult<Clientes> EliminarCliente([FromBody] Clientes entidad)
        {
            try
            {
                if (this.iClientes == null) throw new Exception("No implementado");
                return Ok(this.iClientes.Eliminar(entidad));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}