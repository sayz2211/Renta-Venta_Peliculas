using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface IEmpleados_Presentacion
    {
        List<Empleados> Consultar();
        Empleados Guardar(Empleados entidad);
        Empleados Modificar(Empleados entidad);
        Empleados Eliminar(Empleados entidad);
    }
}
