using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class TiposGenerosHTMLModel : PageModel
    {
        private ITiposGeneros_Presentacion? ITiposGeneros;
        [BindProperty] public List<TiposGeneros>? Lista { get; set; }
        [BindProperty] public TiposGeneros? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public TiposGenerosHTMLModel()
        {
            ITiposGeneros = new TiposGeneros_Presentacion();
        }

        public void OnGet()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(session)) { HttpContext.Response.Redirect("/"); return; }
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                Lista = ITiposGeneros!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo() { Actual = new TiposGeneros(); Lista = null; }

        public void OnPostBtModificar(int data)
        {
            OnPostBtRefrescar();
            Actual = Lista?.FirstOrDefault(x => x.Id == data);
            Lista = null;
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual == null) return;
              
                Actual = ITiposGeneros!.Guardar(Actual!);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }
    }
}