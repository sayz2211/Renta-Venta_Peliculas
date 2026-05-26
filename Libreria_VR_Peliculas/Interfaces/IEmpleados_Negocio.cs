using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IEmpleados_Negocio
    {
        List<Empleados> Consultar();
        Empleados Guardar(Empleados entidad);
        Empleados Modificar(Empleados entidad);
        Empleados Eliminar(Empleados entidad);
    }
}
