using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface ITiposGeneros_Presentacion
    {
        List<TiposGeneros> Consultar();
        TiposGeneros Guardar(TiposGeneros entidad);
        TiposGeneros Modificar(TiposGeneros entidad);
    }
}
