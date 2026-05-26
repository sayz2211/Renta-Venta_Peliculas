using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IProveedores_Presentacion
    {
        List<Proveedores> Consultar();
        Proveedores Guardar(Proveedores entidad);
        Proveedores Modificar(Proveedores entidad);
        Proveedores Eliminar(Proveedores entidad);
    }
}
