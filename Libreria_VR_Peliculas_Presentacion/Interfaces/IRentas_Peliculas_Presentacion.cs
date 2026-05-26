using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IRentas_Peliculas_Presentacion
    {
        List<Rentas_Peliculas> Consultar();
        Rentas_Peliculas Guardar(Rentas_Peliculas entidad);
    }
}
