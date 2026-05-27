using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface IFormatos_Presentacion
    {
        List<Formatos> Consultar();
        Formatos Guardar(Formatos entidad);
        Formatos Modificar(Formatos entidad);
    }
}
