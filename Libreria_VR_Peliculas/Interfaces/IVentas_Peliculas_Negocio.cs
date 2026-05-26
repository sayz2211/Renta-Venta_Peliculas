using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IVentas_Peliculas_Negocio
    {
        List<Ventas_Peliculas> Consultar();
        Ventas_Peliculas Guardar(Ventas_Peliculas entidad);
    }
}
