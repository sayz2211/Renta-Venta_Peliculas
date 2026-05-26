using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmpleadosController : ControllerBase
    {
        private IEmpleados_Negocio iEmpleados;

        public EmpleadosController()
        {
            this.iEmpleados = new Empleados_Negocio();
        }

        [HttpGet]
        public List<Empleados> ConsultarEmpleados()
        {
            if (this.iEmpleados == null) throw new Exception("No implementado");
            return this.iEmpleados.Consultar();
        }

        [HttpPost]
        public Empleados GuardarEmpleado([FromBody] Empleados entidad)
        {
            if (this.iEmpleados == null) throw new Exception("No implementado");
            return this.iEmpleados.Guardar(entidad);
        }

        [HttpPut]
        public Empleados ModificarEmpleado([FromBody] Empleados entidad)
        {
            if (this.iEmpleados == null) throw new Exception("No implementado");
            return this.iEmpleados.Modificar(entidad);
        }

        [HttpDelete]
        public Empleados EliminarEmpleado([FromBody] Empleados entidad)
        {
            if (this.iEmpleados == null) throw new Exception("No implementado");
            return this.iEmpleados.Eliminar(entidad);
        }
    }
}
