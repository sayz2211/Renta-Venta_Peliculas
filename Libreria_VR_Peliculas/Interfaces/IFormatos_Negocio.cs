using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IFormatos_Negocio
    {
        List<Formatos> Consultar();
        Formatos Guardar(Formatos entidad);
        Formatos Modificar(Formatos entidad);
    }
}
