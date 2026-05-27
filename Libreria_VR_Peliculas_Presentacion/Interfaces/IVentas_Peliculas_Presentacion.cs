using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface IVentas_Peliculas_Presentacion
    {
        List<Ventas_Peliculas> Consultar();
        Ventas_Peliculas Guardar(Ventas_Peliculas entidad);
    }
}
