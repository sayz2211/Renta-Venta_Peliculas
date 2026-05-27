using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface IDescuentos_Presentacion

    {
        List<Descuentos> Consultar();
        Descuentos Guardar(Descuentos entidad);
        Descuentos Modificar(Descuentos entidad);
    }
}
