using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface ITiposGeneros_Negocio
    {
        List<TiposGeneros> Consultar();
        TiposGeneros Guardar(TiposGeneros entidad);
        TiposGeneros Modificar(TiposGeneros entidad);
    }
}
