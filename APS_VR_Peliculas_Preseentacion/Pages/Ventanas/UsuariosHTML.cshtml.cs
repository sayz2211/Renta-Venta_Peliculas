using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class UsuariosHTMLModel : PageModel
    {
        private IUsuarios_Presentacion? IUsuarios;
        [BindProperty] public List<Usuarios>? Lista { get; set; }
        [BindProperty] public Usuarios? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public UsuariosHTMLModel()
        {
            IUsuarios = new Usuarios_Presentacion();
        }

        public void OnGet()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(session)) { HttpContext.Response.Redirect("/"); return; }
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                Lista = IUsuarios!.Consultar();
                Actual = null;
                Borrando = false;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo() { Actual = new Usuarios(); Lista = null; }

        public void OnPostBtModificar(int data)
        {
            OnPostBtRefrescar();
            Actual = Lista?.FirstOrDefault(x => x.Id == data);
            Lista = null;
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual == null) return;
              
                Actual = IUsuarios!.Guardar(Actual!);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            OnPostBtRefrescar();
            Actual = Lista?.FirstOrDefault(x => x.Id == data);
            Lista = null;
            Borrando = true;
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Actual != null) IUsuarios!.Eliminar(Actual!);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() => OnPostBtRefrescar();
    }
}