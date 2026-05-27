using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface IReclamos_Presentacion
    {
        List<Reclamos> Consultar();
        Reclamos Guardar(Reclamos entidad);
    }
}
