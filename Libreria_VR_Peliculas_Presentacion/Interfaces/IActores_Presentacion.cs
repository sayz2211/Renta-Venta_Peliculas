using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IActores_Presentacion
    {
        List<Actores> Consultar();
        Actores Guardar(Actores entidad);
        Actores Modificar(Actores entidad);
        Actores Eliminar(Actores entidad);
    }
}
