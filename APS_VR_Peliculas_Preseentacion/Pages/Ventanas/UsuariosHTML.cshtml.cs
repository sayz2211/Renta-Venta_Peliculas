using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class UsuariosHTMLModel : PageModel
    {
        private IUsuarios_Presentacion? IUsuarios;
        private IRoles_Presentacion? IRoles;
        [BindProperty] public List<Usuarios>? Lista { get; set; }
        [BindProperty] public Usuarios? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Roles>? ListaRoles { get; set; }

        public UsuariosHTMLModel()
        {
            IUsuarios = new Usuarios_Presentacion();
            IRoles = new Roles_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaRoles = IRoles!.Consultar(); } catch { ListaRoles = new List<Roles>(); }
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario"))) { HttpContext.Response.Redirect("/"); return; }
            CargarListas(); OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try { CargarListas(); Lista = IUsuarios!.Consultar(); Actual = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Usuarios { FechaRegistro = DateTime.Now, Activo = true };
            Lista = null;
        }

        public void OnPostBtModificar(int data)
        {
            CargarListas(); OnPostBtRefrescar();
            Actual = Lista?.FirstOrDefault(x => x.Id == data);
            Lista = null; Borrando = false;
        }

        public void OnPostBtGuardar()
        {
            try
            {
                CargarListas();
                if (Actual == null) return;
                if (string.IsNullOrEmpty(Actual.NombreUsuario)) throw new Exception("El nombre de usuario es obligatorio.");
                if (Actual.Roles == null || Actual.Roles == 0) throw new Exception("Debe seleccionar un Rol.");
                if (Actual.Id == 0) { Actual.FechaRegistro = DateTime.Now; Actual = IUsuarios!.Guardar(Actual!); }
                else Actual = IUsuarios!.Modificar(Actual!);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }

        public void OnPostBtBorrarVal(int data)
        {
            CargarListas(); OnPostBtRefrescar();
            Actual = Lista?.FirstOrDefault(x => x.Id == data);
            Lista = null; Borrando = true;
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Actual == null) return;
                // Desactivar — no eliminar, puede tener auditorías asociadas
                Actual.Activo = false;
                IUsuarios!.Modificar(Actual!);
                ViewData["Mensaje"] = "Usuario desactivado correctamente.";
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }

        public void OnPostBtCerrar() { CargarListas(); OnPostBtRefrescar(); }
    }
}
