using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class RepartosHTMLModel : PageModel
    {
        private IRepartos_Presentacion? IRepartos;
        private IActores_Presentacion? IActores;
        private IPeliculas_Presentacion? IPeliculas;
        [BindProperty] public List<Repartos>? Lista { get; set; }
        [BindProperty] public Repartos? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Actores>? ListaActores { get; set; }
        public List<Peliculas>? ListaPeliculas { get; set; }

        public RepartosHTMLModel()
        {
            IRepartos = new Repartos_Presentacion();
            IActores = new Actores_Presentacion();
            IPeliculas = new Peliculas_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaActores = IActores!.Consultar(); } catch { ListaActores = new List<Actores>(); }
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
                Lista = IRepartos!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Repartos();
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
                Borrando = false;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                CargarListas();
                if (Actual == null) return;
                Actual = IRepartos!.Guardar(Actual!);
                if (Actual.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }
    }
}
