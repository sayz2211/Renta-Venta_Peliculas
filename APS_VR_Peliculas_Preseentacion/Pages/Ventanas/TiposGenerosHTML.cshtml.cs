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
        private IPeliculas_Presentacion? IPeliculas;
        [BindProperty] public List<TiposGeneros>? Lista { get; set; }
        [BindProperty] public TiposGeneros? Actual { get; set; }
        public List<Peliculas>? ListaPeliculas { get; set; }

        public TiposGenerosHTMLModel()
        {
            ITiposGeneros = new TiposGeneros_Presentacion();
            IPeliculas = new Peliculas_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaPeliculas = IPeliculas!.Consultar(); } catch { ListaPeliculas = new List<Peliculas>(); }
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario"))) { HttpContext.Response.Redirect("/"); return; }
            CargarListas(); OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try { CargarListas(); Lista = ITiposGeneros!.Consultar(); Actual = null; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo() { CargarListas(); Actual = new TiposGeneros(); Lista = null; }

        public void OnPostBtModificar(int data)
        {
            CargarListas(); OnPostBtRefrescar();
            Actual = Lista?.FirstOrDefault(x => x.Id == data);
            Lista = null;
        }

        public void OnPostBtGuardar()
        {
            try
            {
                CargarListas();
                if (Actual == null) return;
                if (Actual.Peliculas == null || Actual.Peliculas == 0) throw new Exception("Debe seleccionar una Película.");
                Actual = ITiposGeneros!.Guardar(Actual!);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }
    }
}
