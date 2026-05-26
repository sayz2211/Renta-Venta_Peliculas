using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IFormatos_Peliculas_Negocio
    {
        List<Formatos_Peliculas> Consultar();
        Formatos_Peliculas Guardar(Formatos_Peliculas entidad);
        Formatos_Peliculas Modificar(Formatos_Peliculas entidad);
    }
}
