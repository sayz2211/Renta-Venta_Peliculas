using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class DevolucionesHTMLModel : PageModel
    {
        private IDevoluciones_Presentacion? IDevoluciones;
        private IClientes_Presentacion? IClientes;
        private IPeliculas_Presentacion? IPeliculas;
        private IFacturas_Presentacion? IFacturas;
        [BindProperty] public List<Devoluciones>? Lista { get; set; }
        [BindProperty] public Devoluciones? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Clientes>? ListaClientes { get; set; }
        public List<Peliculas>? ListaPeliculas { get; set; }
        public List<Facturas>? ListaFacturas { get; set; }

        public DevolucionesHTMLModel()
        {
            IDevoluciones = new Devoluciones_Presentacion();
            IClientes = new Clientes_Presentacion();
            IPeliculas = new Peliculas_Presentacion();
            IFacturas = new Facturas_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaClientes = IClientes!.Consultar(); } catch { ListaClientes = new List<Clientes>(); }
            try { ListaPeliculas = IPeliculas!.Consultar(); } catch { ListaPeliculas = new List<Peliculas>(); }
            try { ListaFacturas = IFacturas!.Consultar(); } catch { ListaFacturas = new List<Facturas>(); }
        }

        public void OnGet()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(session))
            {
                HttpContext.Response.Redirect("/");
                return;
            }
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                var session = HttpContext.Session.GetString("Usuario");
                if (string.IsNullOrEmpty(session)) { HttpContext.Response.Redirect("/"); return; }
                CargarListas();
                Lista = IDevoluciones!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Devoluciones { Fecha = DateTime.Now };
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
                if (Actual.Clientes == null || Actual.Clientes == 0) throw new Exception("Debe seleccionar un Cliente.");
                if (Actual.Peliculas == null || Actual.Peliculas == 0) throw new Exception("Debe seleccionar una Película.");
                Actual = IDevoluciones!.Guardar(Actual!);
                if (Actual.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }
        
    }
}
