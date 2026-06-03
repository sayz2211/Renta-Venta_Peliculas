using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class PeliculasHTMLModel : PageModel
    {
        private IPeliculas_Presentacion? IPeliculas;
        private IDirectores_Presentacion? IDirectores;
        [BindProperty] public List<Peliculas>? Lista { get; set; }
        [BindProperty] public Peliculas? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Directores>? ListaDirectores { get; set; }

        public PeliculasHTMLModel()
        {
            IPeliculas = new Peliculas_Presentacion();
            IDirectores = new Directores_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaDirectores = IDirectores!.Consultar(); } catch { ListaDirectores = new List<Directores>(); }
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario"))) { HttpContext.Response.Redirect("/"); return; }
            CargarListas(); OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try { CargarListas(); Lista = IPeliculas!.Consultar(); Actual = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo() { CargarListas(); Actual = new Peliculas { Disponibilidad = true }; Lista = null; }

        public void OnPostBtModificar(int data)
        {
            try { CargarListas(); OnPostBtRefrescar(); Actual = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                CargarListas();
                if (Actual == null) return;
                if (Actual.Id == 0) Actual = IPeliculas!.Guardar(Actual!);
                else Actual = IPeliculas!.Modificar(Actual!);
                if (Actual.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try { CargarListas(); OnPostBtRefrescar(); Actual = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = true; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Actual == null) return;
                // Desactivar en lugar de eliminar — conserva historial de rentas/ventas
                Actual.Disponibilidad = false;
                IPeliculas!.Modificar(Actual!);
                ViewData["Mensaje"] = "Película desactivada correctamente.";
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }

        public void OnPostBtCerrar() { CargarListas(); OnPostBtRefrescar(); Borrando = false; }
    }
}
