using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface IRentas_Presentacion
    {
        List<Rentas> Consultar();
        Rentas Guardar(Rentas entidad);
    }
}
