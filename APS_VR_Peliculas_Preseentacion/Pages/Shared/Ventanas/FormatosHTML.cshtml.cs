using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class FormatosHTMLModel : PageModel
    {
        private  IFormatos_Presentacion? IFormatos;
        [BindProperty] public List<Formatos>? Lista { get; set; }
        [BindProperty] public Formatos? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public FormatosHTMLModel()
        {
            IFormatos = new Formatos_Presentacion();
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
                Lista = IFormatos!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            Actual = new Formatos();
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
                if (Actual.Id == 0)
                    Actual = IFormatos!.Guardar(Actual!);
                else
                    Actual = IFormatos!.Modificar(Actual!);
                if (Actual.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }
        
    }
}
