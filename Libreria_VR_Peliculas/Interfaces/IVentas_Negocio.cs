using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IVentas_Negocio
    {
        List<Ventas> Consultar();
        Ventas Guardar(Ventas entidad);
    }
}
