using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface IVentas_Presentacion
    {
        List<Ventas> Consultar();
        Ventas Guardar(Ventas entidad);
    }
}
