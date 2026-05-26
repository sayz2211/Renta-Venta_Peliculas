using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IRepartos_Negocio
    {
        List<Repartos> Consultar();
        Repartos Guardar(Repartos entidad);
    }
}
