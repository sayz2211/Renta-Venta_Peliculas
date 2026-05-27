using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface IClientes_Presentacion
    {
        List<Clientes> Consultar();
        Clientes Guardar(Clientes entidad);
        Clientes Modificar(Clientes entidad);
        Clientes Eliminar(Clientes entidad);
    }
}
