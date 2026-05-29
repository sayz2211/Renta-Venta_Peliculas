using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class FacturasHTMLModel : PageModel
    {
        // 1. Interfaces (Asegúrate de que estas clases existan en tu capa de Presentación)
        private IFacturas_Presentacion IFacturas = new Facturas_Presentacion();
        private IClientes_Presentacion IClientes = new Clientes_Presentacion();
        private IRentas_Presentacion IRentas = new Rentas_Presentacion();
        private IVentas_Presentacion IVentas = new Ventas_Presentacion();
        private IDescuentos_Presentacion IDescuentos = new Descuentos_Presentacion();

        [BindProperty] public List<Facturas>? Lista { get; set; }
        [BindProperty] public Facturas? Actual { get; set; }

        // Estas propiedades deben llamarse EXACTAMENTE así para que el HTML las vea
        public List<Clientes>? ListaClientes { get; set; }
        public List<Rentas>? ListaRentas { get; set; }
        public List<Ventas>? ListaVentas { get; set; }
        public List<Descuentos>? ListaDescuentos { get; set; }

        private void CargarListas()
        {
            // Cargamos los datos de la BD a las listas del modelo
            try { ListaClientes = IClientes.Consultar(); } catch { ListaClientes = new List<Clientes>(); }
            try { ListaRentas = IRentas.Consultar(); } catch { ListaRentas = new List<Rentas>(); }
            try { ListaVentas = IVentas.Consultar(); } catch { ListaVentas = new List<Ventas>(); }
            try { ListaDescuentos = IDescuentos.Consultar(); } catch { ListaDescuentos = new List<Descuentos>(); }
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario")))
            {
                HttpContext.Response.Redirect("/");
                return;
            }
            CargarListas();
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                CargarListas();
                Lista = IFacturas.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = "Error al refrescar: " + ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            // Inicializamos con valores por defecto para evitar nulos en BD
            Actual = new Facturas
            {
                Fecha = DateTime.Now,
                Codigo = "FAC-" + DateTime.Now.ToString("mmss"),
                Total = 0,
                Clientes = 0 // Clave foránea según tu tabla dbo.Facturas
            };
            Lista = null;
        }

        public void OnPostBtModificar(int data)
        {
            CargarListas();
            var todas = IFacturas.Consultar();
            Actual = todas?.FirstOrDefault(x => x.Id == data);
            Lista = null;
        }

        public void OnPostBtGuardar()
        {
            try
            {
                CargarListas();
                if (Actual == null) return;

                // Validación de seguridad antes de mandar al API/BD
                if (Actual.Clientes <= 0) throw new Exception("Debe seleccionar un Cliente.");

                // Si el objeto viene del API con error de deserialización (Id=0), 
                // intentamos forzar el guardado
                var resultado = IFacturas.Guardar(Actual);

                if (resultado == null) throw new Exception("El servidor no devolvió respuesta.");

                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
                CargarListas();
            }
        }
    }
}