using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class RolesHTMLModel : PageModel
    {
        private IRoles_Presentacion? IRoles;
        [BindProperty] public List<Roles>? Lista { get; set; }
        [BindProperty] public Roles? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public RolesHTMLModel() { IRoles = new Roles_Presentacion(); }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario"))) { HttpContext.Response.Redirect("/"); return; }
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try { Lista = IRoles!.Consultar(); Actual = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo() { Actual = new Roles { Activo = true }; Lista = null; }

        public void OnPostBtModificar(int data)
        {
            try { OnPostBtRefrescar(); Actual = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual == null) return;
                if (Actual.Id == 0) Actual = IRoles!.Guardar(Actual!);
                else Actual = IRoles!.Modificar(Actual!);
                if (Actual.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try { OnPostBtRefrescar(); Actual = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = true; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Actual == null) return;
                // Desactivar — puede tener usuarios con este rol
                Actual.Activo = false;
                IRoles!.Modificar(Actual!);
                ViewData["Mensaje"] = "Rol desactivado correctamente.";
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() { OnPostBtRefrescar(); Borrando = false; }
    }
}
