using iTextSharp.text;
using iTextSharp.text.pdf;
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
            try { CargarListas(); Lista = IRentas!.Consultar(); Actual = null; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Rentas
            {
                Fecha_Renta = DateTime.Now,
                Fecha_Limite = DateTime.Now.AddDays(3),
                Precio_Dia = 1,  // valor por defecto oculto al usuario
                Cantidad = 1     // valor por defecto oculto al usuario
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
                if (Actual.Clientes == null || Actual.Clientes == 0) throw new Exception("Debe seleccionar un Cliente.");
                if (Actual.Fecha_Renta == default) Actual.Fecha_Renta = DateTime.Now;
                if (Actual.Fecha_Limite <= Actual.Fecha_Renta) Actual.Fecha_Limite = Actual.Fecha_Renta.AddDays(1);

                // Forzar valores por defecto para campos ocultos
                Actual.Precio_Dia = 1;
                Actual.Cantidad = 1;

                Actual = IRentas!.Guardar(Actual!);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }
        public IActionResult OnPostBtPDF()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(session)) return Redirect("/");

            CargarListas();
            Lista = IRentas!.Consultar();

            using var ms = new MemoryStream();
            var doc = new Document(PageSize.A4.Rotate(), 30, 30, 40, 30);
            PdfWriter.GetInstance(doc, ms);
            doc.Open();

            var titulo = new Paragraph("Reporte de Rentas",
                new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 15;
            doc.Add(titulo);

            doc.Add(new Paragraph($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}",
                new Font(Font.FontFamily.HELVETICA, 9)) { SpacingAfter = 10 });

            var tabla = new PdfPTable(6) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 1, 3, 2, 1.5f, 2, 2 });

            BaseColor gris = new BaseColor(52, 58, 64);
            Font fEnc = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD, BaseColor.WHITE);
            tabla.AddCell(new PdfPCell(new Phrase("ID", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Cliente", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Precio/Día", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Cantidad", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Fecha Renta", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Fecha Límite", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });

            Font fCelda = new Font(Font.FontFamily.HELVETICA, 9);
            foreach (var e in Lista!)
            {
                var cliente = ListaClientes?.FirstOrDefault(c => c.Id == e.Clientes)?.Nombre ?? e.Clientes.ToString();
                tabla.AddCell(e.Id.ToString());
                tabla.AddCell(cliente);
                tabla.AddCell(e.Precio_Dia.ToString("C0"));
                tabla.AddCell(e.Cantidad.ToString());
                tabla.AddCell(e.Fecha_Renta.ToString("yyyy-MM-dd"));
                tabla.AddCell(e.Fecha_Limite.ToString("yyyy-MM-dd"));
            }

            doc.Add(tabla);
            doc.Close();

            return File(ms.ToArray(), "application/pdf", "Reporte_de_Rentas.pdf");
        }

    }
}
