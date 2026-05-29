using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class Rentas_PeliculasHTMLModel : PageModel
    {
        private IRentas_Peliculas_Presentacion? IRentasPelis;
        private IRentas_Presentacion? IRentas;
        private IPeliculas_Presentacion? IPeliculas;

        [BindProperty] public List<Rentas_Peliculas>? Lista { get; set; }
        [BindProperty] public Rentas_Peliculas? Actual { get; set; }
        public List<Rentas>? ListaRentas { get; set; }
        public List<Peliculas>? ListaPeliculas { get; set; }

        public Rentas_PeliculasHTMLModel()
        {
            IRentasPelis = new Rentas_Peliculas_Presentacion();
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
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario"))) { HttpContext.Response.Redirect("/"); return; }
            CargarListas();
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try { CargarListas(); Lista = IRentasPelis!.Consultar(); Actual = null; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
     
            Actual = new Rentas_Peliculas
            {
                Cantidad = 1,
                Dias = 1,
                Precio_Dia = 0,
                Subtotal = 0,
                Rentas = 0 
            };
            Lista = null;
        }
        public void OnPostBtGuardar()
        {
            try
            {
                CargarListas();
                if (Actual == null) return;

              
                if (Actual.Rentas == 0 || Actual.Rentas == null) throw new Exception("Debe vincular una Renta válida.");
                if (Actual.Peliculas == 0 || Actual.Peliculas == null) throw new Exception("Debe seleccionar una Película.");
                if (Actual.Cantidad <= 0) Actual.Cantidad = 1;
                if (Actual.Dias <= 0) Actual.Dias = 1;

                if (Actual.Subtotal <= 0)
                {
                    Actual.Subtotal = Actual.Cantidad * Actual.Dias * Actual.Precio_Dia;
                }

                Actual = IRentasPelis!.Guardar(Actual!);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }
    }
}