using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class ReclamosHTMLModel : PageModel
    {
        private IReclamos_Presentacion? IReclamos;
        private IFacturas_Presentacion? IFacturas;
        [BindProperty] public List<Reclamos>? Lista { get; set; }
        [BindProperty] public Reclamos? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Facturas>? ListaFacturas { get; set; }

        public ReclamosHTMLModel()
        {
            IReclamos = new Reclamos_Presentacion();
            IFacturas = new Facturas_Presentacion();
        }

        private void CargarListas()
        {
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
                Lista = IReclamos!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Reclamos { Fecha = DateTime.Now };
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
                if (Actual.Facturas == null || Actual.Facturas == 0) throw new Exception("Debe seleccionar una Factura.");
                Actual = IReclamos!.Guardar(Actual!);
                if (Actual.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }
        
    }
}
