using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas.Interfaces
{
    public interface IUsuarios_Negocio
    {
        List<Usuarios> Consultar();
        Usuarios Guardar(Usuarios entidad);
        Usuarios Modificar(Usuarios entidad);
        Usuarios Eliminar(Usuarios entidad);
        Usuarios? Login(string nombreUsuario, string contrasena);
    }
}
