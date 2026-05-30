using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class VentasHTMLModel : PageModel
    {
        private IVentas_Presentacion? IVentas;
        private IClientes_Presentacion? IClientes;
        [BindProperty] public List<Ventas>? Lista { get; set; }
        [BindProperty] public Ventas? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Clientes>? ListaClientes { get; set; }

        public VentasHTMLModel()
        {
            IVentas = new Ventas_Presentacion();
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
            try { CargarListas(); Lista = IVentas!.Consultar(); Actual = null; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Ventas { Precio_Venta = 1, Cantidad = 1 };
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
                if (Actual == null) { ViewData["Mensaje"] = "Error: no hay datos."; return; }
                if (Actual.Clientes == null || Actual.Clientes == 0) { ViewData["Mensaje"] = "Debe seleccionar un Cliente."; return; }
                // Forzar valores por defecto para campos ocultos
                Actual.Precio_Venta = 1;
                Actual.Cantidad = 1;
                Actual = IVentas!.Guardar(Actual!);
                if (Actual.Id == 0) { ViewData["Mensaje"] = "No se pudo guardar."; CargarListas(); return; }
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }
        public IActionResult OnPostBtPDF()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(session)) return Redirect("/");

            CargarListas();
            Lista = IVentas!.Consultar();

            using var ms = new MemoryStream();
            var doc = new Document(PageSize.A4.Rotate(), 30, 30, 40, 30);
            PdfWriter.GetInstance(doc, ms);
            doc.Open();

            var titulo = new Paragraph("Reporte de Ventas",
                new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 15;
            doc.Add(titulo);

            doc.Add(new Paragraph($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}",
                new Font(Font.FontFamily.HELVETICA, 9)) { SpacingAfter = 10 });

            var tabla = new PdfPTable(4) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 1, 4, 2, 2 });

            BaseColor gris = new BaseColor(52, 58, 64);
            Font fEnc = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD, BaseColor.WHITE);
            tabla.AddCell(new PdfPCell(new Phrase("ID", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Cliente", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Precio Venta", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Cantidad", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });

            Font fCelda = new Font(Font.FontFamily.HELVETICA, 9);
            foreach (var e in Lista!)
            {
                var cliente = ListaClientes?.FirstOrDefault(c => c.Id == e.Clientes)?.Nombre ?? e.Clientes.ToString();
                tabla.AddCell(e.Id.ToString());
                tabla.AddCell(cliente);
                tabla.AddCell(e.Precio_Venta.ToString("C0"));
                tabla.AddCell(e.Cantidad.ToString());
            }

            doc.Add(tabla);
            doc.Close();

            return File(ms.ToArray(), "application/pdf", "Reporte_de_Ventas.pdf");
        }

    }
}
