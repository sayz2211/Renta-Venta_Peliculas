using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface IDevoluciones_Presentacion
    {
        List<Devoluciones> Consultar();
        Devoluciones Guardar(Devoluciones entidad);
    }
}
