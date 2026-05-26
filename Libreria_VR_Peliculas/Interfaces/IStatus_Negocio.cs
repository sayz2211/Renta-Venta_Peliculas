using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IStatus_Negocio
    {
        List<Status> Consultar();
        Status Guardar(Status entidad);
    }
}
