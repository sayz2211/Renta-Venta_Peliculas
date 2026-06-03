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
        private IPeliculas_Presentacion? IPeliculas;
        private IFormatos_Presentacion? IFormatos;
        private IInventarios_Presentacion? IInventarios;
        [BindProperty] public List<Formatos_Peliculas>? Lista { get; set; }
        [BindProperty] public Formatos_Peliculas? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Peliculas>? ListaPeliculas { get; set; }
        public List<Formatos>? ListaFormatos { get; set; }
        public List<Inventarios>? ListaInventarios { get; set; }

        public Formatos_PeliculasHTMLModel()
        {
            IFormatos_Peliculas = new Formatos_Peliculas_Presentacion();
            IPeliculas = new Peliculas_Presentacion();
            IFormatos = new Formatos_Presentacion();
            IInventarios = new Inventarios_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaPeliculas = IPeliculas!.Consultar(); } catch { ListaPeliculas = new List<Peliculas>(); }
            try { ListaFormatos = IFormatos!.Consultar(); } catch { ListaFormatos = new List<Formatos>(); }
            try { ListaInventarios = IInventarios!.Consultar(); } catch { ListaInventarios = new List<Inventarios>(); }
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario"))) { HttpContext.Response.Redirect("/"); return; }
            CargarListas(); OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try { CargarListas(); Lista = IFormatos_Peliculas!.Consultar(); Actual = null; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo() { CargarListas(); Actual = new Formatos_Peliculas(); Lista = null; }

        public void OnPostBtModificar(int data)
        {
            try { CargarListas(); OnPostBtRefrescar(); Actual = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                CargarListas();
                if (Actual == null) return;
                if (Actual.Peliculas == null || Actual.Peliculas == 0) throw new Exception("Debe seleccionar una Película.");
                if (Actual.Formatos == null || Actual.Formatos == 0) throw new Exception("Debe seleccionar un Formato.");
                if (Actual.Id == 0) Actual = IFormatos_Peliculas!.Guardar(Actual!);
                else Actual = IFormatos_Peliculas!.Modificar(Actual!);
                if (Actual.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }
    }
}
