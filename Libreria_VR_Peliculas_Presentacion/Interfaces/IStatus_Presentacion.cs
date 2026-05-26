using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IStatus_Presentacion
    {
        List<Status> Consultar();
        Status Guardar(Status entidad);
    }
}
