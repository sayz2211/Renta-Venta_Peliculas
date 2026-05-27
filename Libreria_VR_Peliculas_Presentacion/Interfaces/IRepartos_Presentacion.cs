using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface IRepartos_Presentacion
    {
        List<Repartos> Consultar();
        Repartos Guardar(Repartos entidad);
    }
}
