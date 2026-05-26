using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IFacturas_Presentacion
    {
        List<Facturas> Consultar();
        Facturas Guardar(Facturas entidad);
    }
}
