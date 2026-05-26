using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IDirectores_Negocio
    {
        List<Directores> Consultar();
        Directores Guardar(Directores entidad);
        Directores Modificar(Directores entidad);
        Directores Eliminar(Directores entidad);
    }
}
