using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IDevoluciones_Negocio
    {
        List<Devoluciones> Consultar();
        Devoluciones Guardar(Devoluciones entidad);
    }
}
