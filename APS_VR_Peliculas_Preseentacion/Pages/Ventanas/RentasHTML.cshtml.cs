using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;



namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class RentasHTMLModel : PageModel
    {
        private IRentas_Presentacion? IRentas;
        private IClientes_Presentacion? IClientes;

        [BindProperty] public List<Rentas>? Lista { get; set; }
        [BindProperty] public Rentas? Actual { get; set; }
        public List<Clientes>? ListaClientes { get; set; }

        public RentasHTMLModel()
        {
            IRentas = new Rentas_Presentacion();
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
            try
            {
                CargarListas();
                Lista = IRentas!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Rentas
            {
                Fecha_Renta = DateTime.Now,
                Fecha_Limite = DateTime.Now.AddDays(3),
                Precio_Dia = 1, 
                Cantidad = 1    
            };
            Lista = null;
        }

        public void OnPostBtModificar(int data)
        {
            CargarListas();
            OnPostBtRefrescar();
            Actual = Lista?.FirstOrDefault(x => x.Id == data);
            Lista = null;
        }

        public void OnPostBtGuardar()
        {
            try
            {
                CargarListas();
                if (Actual == null) return;

                if (Actual.Fecha_Renta == default) Actual.Fecha_Renta = DateTime.Now;
                if (Actual.Fecha_Limite <= Actual.Fecha_Renta) Actual.Fecha_Limite = Actual.Fecha_Renta.AddDays(1);
                if (Actual.Precio_Dia <= 0) Actual.Precio_Dia = 1000; 
                if (Actual.Cantidad <= 0) Actual.Cantidad = 1;

                Actual = IRentas!.Guardar(Actual!);
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