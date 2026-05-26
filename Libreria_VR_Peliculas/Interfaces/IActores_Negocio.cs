using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IActores_Negocio
    {
        List<Actores> Consultar();
        Actores Guardar(Actores entidad);
        Actores Modificar(Actores entidad);
        Actores Eliminar(Actores entidad);
    }
}
