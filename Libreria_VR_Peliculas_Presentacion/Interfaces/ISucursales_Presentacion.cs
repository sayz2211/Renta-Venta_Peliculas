using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface ISucursales_Presentacion
    {
        List<Sucursales> Consultar();
        Sucursales Guardar(Sucursales entidad);
        Sucursales Modificar(Sucursales entidad);
        Sucursales Eliminar(Sucursales entidad);
    }
}
