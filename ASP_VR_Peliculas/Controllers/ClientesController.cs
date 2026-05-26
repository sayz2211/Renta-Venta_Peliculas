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
        public List<Clientes> ConsultarClientes()
        {
            if (this.iClientes == null) throw new Exception("No implementado");
            return this.iClientes.Consultar();
        }

        [HttpPost]
        public Clientes GuardarCliente([FromBody] Clientes entidad)
        {
            if (this.iClientes == null) throw new Exception("No implementado");
            return this.iClientes.Guardar(entidad);
        }

        [HttpPut]
        public Clientes ModificarCliente([FromBody] Clientes entidad)
        {
            if (this.iClientes == null) throw new Exception("No implementado");
            return this.iClientes.Modificar(entidad);
        }

        [HttpDelete]
        public Clientes EliminarCliente([FromBody] Clientes entidad)
        {
            if (this.iClientes == null) throw new Exception("No implementado");
            return this.iClientes.Eliminar(entidad);
        }
    }
}
