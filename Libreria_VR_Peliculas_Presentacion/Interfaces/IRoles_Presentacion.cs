using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IRoles_Presentacion
    {
        List<Roles> Consultar();
        Roles Guardar(Roles entidad);
        Roles Modificar(Roles entidad);
    }
}
