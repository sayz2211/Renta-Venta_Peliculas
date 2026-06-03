using iTextSharp.text;
using iTextSharp.text.pdf;
using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class ClientesHTMLModel : PageModel
    {
        private IClientes_Presentacion? IClientes;
        private IMembresias_Presentacion? IMembresias;
        private IStatus_Presentacion? IStatus;
        [BindProperty] public List<Clientes>? Lista { get; set; }
        [BindProperty] public Clientes? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Membresias>? ListaMembresias { get; set; }
        public List<Status>? ListaStatus { get; set; }

        public ClientesHTMLModel()
        {
            IClientes = new Clientes_Presentacion();
            IMembresias = new Membresias_Presentacion();
            IStatus = new Status_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaMembresias = IMembresias!.Consultar(); } catch { ListaMembresias = new List<Membresias>(); }
            try { ListaStatus = IStatus!.Consultar(); } catch { ListaStatus = new List<Status>(); }
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario"))) { HttpContext.Response.Redirect("/"); return; }
            CargarListas();
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try { CargarListas(); Lista = IClientes!.Consultar(); Actual = null; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo() { CargarListas(); Actual = new Clientes(); Lista = null; }

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
                if (Actual.Id == 0) Actual = IClientes!.Guardar(Actual!);
                else Actual = IClientes!.Modificar(Actual!);
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
            try { if (Actual == null) return; Actual = IClientes!.Eliminar(Actual!); OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() { CargarListas(); OnPostBtRefrescar(); Borrando = false; }

        public IActionResult OnPostBtPDF()
        {
            Lista = IClientes!.Consultar();
            using var ms = new MemoryStream();
            var doc = new Document(PageSize.A4, 30, 30, 40, 30);
            PdfWriter.GetInstance(doc, ms);
            doc.Open();
            var titulo = new Paragraph("Reporte de Clientes", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
            titulo.Alignment = Element.ALIGN_CENTER; titulo.SpacingAfter = 15;
            doc.Add(titulo);
            doc.Add(new Paragraph($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}", new Font(Font.FontFamily.HELVETICA, 9)) { SpacingAfter = 10 });
            var tabla = new PdfPTable(5) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 1, 3, 2, 3, 2 });
            BaseColor gris = new BaseColor(52, 58, 64);
            Font fEnc = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD, BaseColor.WHITE);
            foreach (var h in new[] { "ID", "Nombre", "Cédula", "Correo", "Teléfono" })
                tabla.AddCell(new PdfPCell(new Phrase(h, fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            Font fFila = new Font(Font.FontFamily.HELVETICA, 9);
            bool par = false;
            foreach (var e in Lista!)
            {
                BaseColor bg = par ? new BaseColor(240, 240, 240) : BaseColor.WHITE;
                foreach (var val in new[] { e.Id.ToString(), e.Nombre ?? "", e.Cedula ?? "", e.Correo ?? "", e.Telefono ?? "" })
                    tabla.AddCell(new PdfPCell(new Phrase(val, fFila)) { BackgroundColor = bg, Padding = 5 });
                par = !par;
            }
            doc.Add(tabla); doc.Close();
            return File(ms.ToArray(), "application/pdf", "Clientes.pdf");
        }
    }
}
