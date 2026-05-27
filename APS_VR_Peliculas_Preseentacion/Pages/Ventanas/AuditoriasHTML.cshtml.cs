using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class AuditoriasHTMLModel : PageModel
    {
        private IAuditorias_Presentacion? IAuditorias;
        [BindProperty] public List<Auditorias>? Lista { get; set; }
        [BindProperty] public Auditorias? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public AuditoriasHTMLModel()
        {
            IAuditorias = new Auditorias_Presentacion();
        }

        public void OnGet()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(session))
            {
                HttpContext.Response.Redirect("/");
                return;
            }
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                var session = HttpContext.Session.GetString("Usuario");
                if (string.IsNullOrEmpty(session)) { HttpContext.Response.Redirect("/"); return; }
                Lista = IAuditorias!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            Actual = new Auditorias();
            Lista = null;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Actual = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual == null) return;
                Actual = IAuditorias!.Guardar(Actual!);
                if (Actual.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }
        
    }
}
