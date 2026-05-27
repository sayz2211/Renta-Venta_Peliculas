using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Interfaces
{
    public interface IUsuarios_Presentacion
    {
        List<Usuarios> Consultar();
        Usuarios Guardar(Usuarios entidad);
        Usuarios Modificar(Usuarios entidad);
        Usuarios Eliminar(Usuarios entidad);
        Usuarios? Login(string nombreUsuario, string contrasena);
    }
}
