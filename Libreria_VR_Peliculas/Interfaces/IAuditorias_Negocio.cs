using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IAuditorias_Negocio
    {
        List<Auditorias> Consultar();
        Auditorias Guardar(Auditorias entidad);
    }
}
