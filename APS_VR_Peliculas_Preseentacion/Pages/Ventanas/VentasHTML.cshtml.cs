using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class VentasHTMLModel : PageModel
    {
        private IVentas_Presentacion? IVentas;
        private IClientes_Presentacion? IClientes;
        [BindProperty] public List<Ventas>? Lista { get; set; }
        [BindProperty] public Ventas? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Clientes>? ListaClientes { get; set; }

        public VentasHTMLModel()
        {
            IVentas = new Ventas_Presentacion();
            IClientes = new Clientes_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaClientes = IClientes!.Consultar(); }
            catch { ListaClientes = new List<Clientes>(); }
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario"))) { HttpContext.Response.Redirect("/"); return; }
            CargarListas();
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try { CargarListas(); Lista = IVentas!.Consultar(); Actual = null; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Ventas { Precio_Venta = 1, Cantidad = 1 };
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
                if (Actual.Clientes == null || Actual.Clientes == 0) { ViewData["Mensaje"] = "Debe seleccionar un Cliente."; return; }
                // Forzar valores por defecto para campos ocultos
                Actual.Precio_Venta = 1;
                Actual.Cantidad = 1;
                Actual = IVentas!.Guardar(Actual!);
                if (Actual.Id == 0) { ViewData["Mensaje"] = "No se pudo guardar."; CargarListas(); return; }
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }
    }
}
