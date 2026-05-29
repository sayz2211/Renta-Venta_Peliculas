using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class Ventas_PeliculasHTMLModel : PageModel
    {
        private IVentas_Peliculas_Presentacion? IVentas_Peliculas;
        private IVentas_Presentacion? IVentas;
        private IPeliculas_Presentacion? IPeliculas;
        [BindProperty] public List<Ventas_Peliculas>? Lista { get; set; }
        [BindProperty] public Ventas_Peliculas? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Ventas>? ListaVentas { get; set; }
        public List<Peliculas>? ListaPeliculas { get; set; }

        public Ventas_PeliculasHTMLModel()
        {
            IVentas_Peliculas = new Ventas_Peliculas_Presentacion();
            IVentas = new Ventas_Presentacion();
            IPeliculas = new Peliculas_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaVentas = IVentas!.Consultar(); } catch { ListaVentas = new List<Ventas>(); }
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
                Lista = IVentas_Peliculas!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Ventas_Peliculas
            {
                Cantidad = 1,
                Precio_U = 0,
                Subtotal = 0,
                Ventas = 0 
            };
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
                if (Actual == null) { ViewData["Mensaje"] = "Error: no hay datos."; return; }
                if (Actual.Ventas == null || Actual.Ventas == 0) { ViewData["Mensaje"] = "Debe seleccionar una Venta."; return; }
                if (Actual.Peliculas == null || Actual.Peliculas == 0) { ViewData["Mensaje"] = "Debe seleccionar una Película."; return; }
                if (Actual.Cantidad <= 0) { ViewData["Mensaje"] = "La cantidad debe ser mayor a 0."; return; }
                if (Actual.Precio_U <= 0) { ViewData["Mensaje"] = "El precio unitario debe ser mayor a 0."; return; }
                Actual.Subtotal = Actual.Cantidad * Actual.Precio_U;
                Actual = IVentas_Peliculas!.Guardar(Actual!);
                if (Actual.Id == 0) { ViewData["Mensaje"] = "No se pudo guardar. Verifique los datos."; CargarListas(); return; }
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }
    }
}
