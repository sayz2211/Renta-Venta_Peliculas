using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas_Presentacion.Interfaces;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class EmpleadosHTMLModel : PageModel
    {
        private IEmpleados_Presentacion? IEmpleados;
        private ISucursales_Presentacion? ISucursales;
        private IStatus_Presentacion? IStatus;
        [BindProperty] public List<Empleados>? Lista { get; set; }
        [BindProperty] public Empleados? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Sucursales>? ListaSucursales { get; set; }
        public List<Status>? ListaStatus { get; set; }

        public EmpleadosHTMLModel()
        {
            IEmpleados = new Empleados_Presentacion();
            ISucursales = new Sucursales_Presentacion();
            IStatus = new Status_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaSucursales = ISucursales!.Consultar(); } catch { ListaSucursales = new List<Sucursales>(); }
            try { ListaStatus = IStatus!.Consultar(); } catch { ListaStatus = new List<Status>(); }
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario"))) { HttpContext.Response.Redirect("/"); return; }
            CargarListas(); OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try { CargarListas(); Lista = IEmpleados!.Consultar(); Actual = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo() { CargarListas(); Actual = new Empleados(); Lista = null; }

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
                if (Actual.Id == 0) Actual = IEmpleados!.Guardar(Actual!);
                else Actual = IEmpleados!.Modificar(Actual!);
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
                CargarListas();
                if (Actual == null) return;
                var statusInactivo = ListaStatus?.FirstOrDefault(s => !s.Activo);
                if (statusInactivo != null) Actual.Status = statusInactivo.Id;
                else Actual.Status = null;
                IEmpleados!.Modificar(Actual!);
                ViewData["Mensaje"] = "Empleado desactivado correctamente.";
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }

        public void OnPostBtCerrar() { CargarListas(); OnPostBtRefrescar(); Borrando = false; }
    }
}
