using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IInventarios_Presentacion
    {
        List<Inventarios> Consultar();
        Inventarios Guardar(Inventarios entidad);
        Inventarios Modificar(Inventarios entidad);
    }
}
