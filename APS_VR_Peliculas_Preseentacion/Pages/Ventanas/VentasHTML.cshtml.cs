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
                Lista = IVentas!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Ventas();
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
                if (Actual.Cantidad <= 0) { ViewData["Mensaje"] = "La cantidad debe ser mayor a 0."; return; }
                if (Actual.Precio_Venta <= 0) { ViewData["Mensaje"] = "El precio de venta debe ser mayor a 0."; return; }
                Actual = IVentas!.Guardar(Actual!);
                if (Actual.Id == 0) { ViewData["Mensaje"] = "No se pudo guardar. Verifique los datos."; CargarListas(); return; }
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }
    }
}
