using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IPeliculas_Negocio
    {
        List<Peliculas> Consultar();
        Peliculas Guardar(Peliculas entidad);
        Peliculas Modificar(Peliculas entidad);
        Peliculas Eliminar(Peliculas entidad);
    }
}
