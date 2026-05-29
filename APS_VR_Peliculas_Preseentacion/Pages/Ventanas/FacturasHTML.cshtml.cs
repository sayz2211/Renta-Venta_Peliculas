using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class FacturasHTMLModel : PageModel
    {
        private IFacturas_Presentacion? IFacturas;
        private IClientes_Presentacion? IClientes;
        private IRentas_Presentacion? IRentas;
        private IVentas_Presentacion? IVentas;
        private IDescuentos_Presentacion? IDescuentos;
        [BindProperty] public List<Facturas>? Lista { get; set; }
        [BindProperty] public Facturas? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Clientes>? ListaClientes { get; set; }
        public List<Rentas>? ListaRentas { get; set; }
        public List<Ventas>? ListaVentas { get; set; }
        public List<Descuentos>? ListaDescuentos { get; set; }

        public FacturasHTMLModel()
        {
            IFacturas = new Facturas_Presentacion();
            IClientes = new Clientes_Presentacion();
            IRentas = new Rentas_Presentacion();
            IVentas = new Ventas_Presentacion();
            IDescuentos = new Descuentos_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaClientes = IClientes!.Consultar(); } catch { ListaClientes = new List<Clientes>(); }
            try { ListaRentas = IRentas!.Consultar(); } catch { ListaRentas = new List<Rentas>(); }
            try { ListaVentas = IVentas!.Consultar(); } catch { ListaVentas = new List<Ventas>(); }
            try { ListaDescuentos = IDescuentos!.Consultar(); } catch { ListaDescuentos = new List<Descuentos>(); }
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
                Lista = IFacturas!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Facturas();
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
                Actual = IFacturas!.Guardar(Actual!);
                if (Actual.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }
    }
}

