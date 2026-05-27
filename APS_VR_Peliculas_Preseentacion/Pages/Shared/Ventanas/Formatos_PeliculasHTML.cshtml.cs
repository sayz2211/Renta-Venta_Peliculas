using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas_Presentacion.Interfaces;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class Formatos_PeliculasHTMLModel : PageModel
    {
        private IFormatos_Peliculas_Presentacion? IFormatos_Peliculas;
        [BindProperty] public List<Formatos_Peliculas>? Lista { get; set; }
        [BindProperty] public Formatos_Peliculas? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public Formatos_PeliculasHTMLModel()
        {
            IFormatos_Peliculas = new Formatos_Peliculas_Presentacion();
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
                Lista = IFormatos_Peliculas!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            Actual = new Formatos_Peliculas();
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
                    Actual = IFormatos_Peliculas!.Guardar(Actual!);
                else
                    Actual = IFormatos_Peliculas!.Modificar(Actual!);
                if (Actual.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }
        
    }
}
