using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IRentas_Negocio
    {
        List<Rentas> Consultar();
        Rentas Guardar(Rentas entidad);
    }
}
