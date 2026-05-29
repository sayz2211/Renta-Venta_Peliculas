using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class InventariosHTMLModel : PageModel
    {
        private IInventarios_Presentacion? IInventarios;
        private IPeliculas_Presentacion? IPeliculas;
        private IFormatos_Presentacion? IFormatos;
        private ISucursales_Presentacion? ISucursales;
        private IProveedores_Presentacion? IProveedores;
        [BindProperty] public List<Inventarios>? Lista { get; set; }
        [BindProperty] public Inventarios? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Peliculas>? ListaPeliculas { get; set; }
        public List<Formatos>? ListaFormatos { get; set; }
        public List<Sucursales>? ListaSucursales { get; set; }
        public List<Proveedores>? ListaProveedores { get; set; }

        public InventariosHTMLModel()
        {
            IInventarios = new Inventarios_Presentacion();
            IPeliculas = new Peliculas_Presentacion();
            IFormatos = new Formatos_Presentacion();
            ISucursales = new Sucursales_Presentacion();
            IProveedores = new Proveedores_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaPeliculas = IPeliculas!.Consultar(); } catch { ListaPeliculas = new List<Peliculas>(); }
            try { ListaFormatos = IFormatos!.Consultar(); } catch { ListaFormatos = new List<Formatos>(); }
            try { ListaSucursales = ISucursales!.Consultar(); } catch { ListaSucursales = new List<Sucursales>(); }
            try { ListaProveedores = IProveedores!.Consultar(); } catch { ListaProveedores = new List<Proveedores>(); }
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
                Lista = IInventarios!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Inventarios();
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
                if (Actual.Id == 0)
                    Actual = IInventarios!.Guardar(Actual!);
                else
                    Actual = IInventarios!.Modificar(Actual!);
                if (Actual.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }
    }
}