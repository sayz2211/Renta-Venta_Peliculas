using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface ISucursales_Negocio
    {
        List<Sucursales> Consultar();
        Sucursales Guardar(Sucursales entidad);
        Sucursales Modificar(Sucursales entidad);
        Sucursales Eliminar(Sucursales entidad);
    }
}
