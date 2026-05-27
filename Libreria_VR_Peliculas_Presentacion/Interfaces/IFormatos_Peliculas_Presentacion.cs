using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface IFormatos_Peliculas_Presentacion
    {
        List<Formatos_Peliculas> Consultar();
        Formatos_Peliculas Guardar(Formatos_Peliculas entidad);
        Formatos_Peliculas Modificar(Formatos_Peliculas entidad);
    }
}
