using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class Rentas_PeliculasHTMLModel : PageModel
    {
        private IRentas_Peliculas_Presentacion? IRentas_Peliculas;
        private IRentas_Presentacion? IRentas;
        private IPeliculas_Presentacion? IPeliculas;
        [BindProperty] public List<Rentas_Peliculas>? Lista { get; set; }
        [BindProperty] public Rentas_Peliculas? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Rentas>? ListaRentas { get; set; }
        public List<Peliculas>? ListaPeliculas { get; set; }

        public Rentas_PeliculasHTMLModel()
        {
            IRentas_Peliculas = new Rentas_Peliculas_Presentacion();
            IRentas = new Rentas_Presentacion();
            IPeliculas = new Peliculas_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaRentas = IRentas!.Consultar(); } catch { ListaRentas = new List<Rentas>(); }
            try { ListaPeliculas = IPeliculas!.Consultar(); } catch { ListaPeliculas = new List<Peliculas>(); }
        }

        public void OnGet()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(session)) { HttpContext.Response.Redirect("/"); return; }
            CargarListas();
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                var session = HttpContext.Session.GetString("Usuario");
                if (string.IsNullOrEmpty(session)) { HttpContext.Response.Redirect("/"); return; }
                CargarListas();
                Lista = IRentas_Peliculas!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Rentas_Peliculas();
            Lista = null;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                CargarListas();
                OnPostBtRefrescar();
                Actual = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                CargarListas();
                if (Actual == null) return;
                Actual = IRentas_Peliculas!.Guardar(Actual!);
                if (Actual.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }
    }
}
