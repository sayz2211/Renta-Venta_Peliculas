using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IRentas_Presentacion
    {
        List<Rentas> Consultar();
        Rentas Guardar(Rentas entidad);
    }
}
