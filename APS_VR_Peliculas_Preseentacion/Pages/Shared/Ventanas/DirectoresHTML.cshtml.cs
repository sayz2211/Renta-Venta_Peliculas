using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class DirectoresHTMLModel : PageModel
    {
        private IDirectores_Presentacion? IDirectores;
        [BindProperty] public List<Directores>? Lista { get; set; }
        [BindProperty] public Directores? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public DirectoresHTMLModel()
        {
            IDirectores = new Directores_Presentacion();
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
                Lista = IDirectores!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            Actual = new Directores();
            Lista = null;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
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
                if (Actual == null) return;
                if (Actual.Id == 0)
                    Actual = IDirectores!.Guardar(Actual!);
                else
                    Actual = IDirectores!.Modificar(Actual!);
                if (Actual.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }
        
        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Actual = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = true;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Actual == null) return;
                Actual = IDirectores!.Eliminar(Actual!);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}
