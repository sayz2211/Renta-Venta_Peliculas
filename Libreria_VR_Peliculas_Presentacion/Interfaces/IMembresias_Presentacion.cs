using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IMembresias_Presentacion
    {
        List<Membresias> Consultar();
        Membresias Guardar(Membresias entidad);
        Membresias Modificar(Membresias entidad);
    }
}
