
using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class IndexModel : PageModel
    {
        private IUsuarios_Presentacion? iUsuarios;
        public bool EstaLogueado = false;
        [BindProperty] public string? NombreUsuario { get; set; }
        [BindProperty] public string? Contrasena { get; set; }
        [BindProperty] public string? NuevoUsuario { get; set; }
        [BindProperty] public string? NuevoCorreo { get; set; }
        [BindProperty] public string? NuevaContrasena { get; set; }

        public IndexModel()
        {
            iUsuarios = new Usuarios_Presentacion();
        }

        public void OnGet()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (!string.IsNullOrEmpty(session))
                EstaLogueado = true;
        }

        public void OnPostBtClean()
        {
            try
            {
                NombreUsuario = string.Empty;
                Contrasena = string.Empty;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtRegistrar()
        {
            try
            {
                if (string.IsNullOrEmpty(NuevoUsuario) || string.IsNullOrEmpty(NuevoCorreo) || string.IsNullOrEmpty(NuevaContrasena))
                {
                    ViewData["Mensaje"] = "Todos los campos son obligatorios.";
                    return;
                }
                var usuario = new Usuarios
                {
                    Id = 0,
                    NombreUsuario = NuevoUsuario,
                    Correo = NuevoCorreo,
                    Contrasena = NuevaContrasena,
                    Roles = 3  
                };
                iUsuarios!.Guardar(usuario);
                ViewData["Mensaje"] = "Cuenta creada exitosamente. Ya puedes iniciar sesión.";
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(NombreUsuario) || string.IsNullOrEmpty(Contrasena))
                {
                    ViewData["Mensaje"] = "Debe ingresar usuario y contraseña.";
                    return;
                }
                var usuario = iUsuarios!.Login(NombreUsuario!, Contrasena!);
                if (usuario == null)
                {
                    ViewData["Mensaje"] = "Usuario o contraseña incorrectos.";
                    return;
                }
                HttpContext.Session.SetString("Usuario", NombreUsuario!);
                HttpContext.Session.SetString("Rol", usuario.Roles.ToString()!);
                EstaLogueado = true;
                OnPostBtClean();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }



        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }
    }
}