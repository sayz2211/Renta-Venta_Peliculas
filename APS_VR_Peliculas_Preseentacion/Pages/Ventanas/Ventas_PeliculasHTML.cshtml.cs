using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class Ventas_PeliculasHTMLModel : PageModel
    {
        private IVentas_Peliculas_Presentacion? IVentas_Peliculas;
        private IVentas_Presentacion? IVentas;
        private IPeliculas_Presentacion? IPeliculas;
        [BindProperty] public List<Ventas_Peliculas>? Lista { get; set; }
        [BindProperty] public Ventas_Peliculas? Actual { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        public List<Ventas>? ListaVentas { get; set; }
        public List<Peliculas>? ListaPeliculas { get; set; }

        public Ventas_PeliculasHTMLModel()
        {
            IVentas_Peliculas = new Ventas_Peliculas_Presentacion();
            IVentas = new Ventas_Presentacion();
            IPeliculas = new Peliculas_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaVentas = IVentas!.Consultar(); } catch { ListaVentas = new List<Ventas>(); }
            try { ListaPeliculas = IPeliculas!.Consultar(); } catch { ListaPeliculas = new List<Peliculas>(); }
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
                Lista = IVentas_Peliculas!.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            Actual = new Ventas_Peliculas
            {
                Cantidad = 1,
                Precio_U = 0,
                Subtotal = 0,
                Ventas = 0 
            };
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
                if (Actual.Ventas == null || Actual.Ventas == 0) { ViewData["Mensaje"] = "Debe seleccionar una Venta."; return; }
                if (Actual.Peliculas == null || Actual.Peliculas == 0) { ViewData["Mensaje"] = "Debe seleccionar una Película."; return; }
                if (Actual.Cantidad <= 0) { ViewData["Mensaje"] = "La cantidad debe ser mayor a 0."; return; }
                if (Actual.Precio_U <= 0) { ViewData["Mensaje"] = "El precio unitario debe ser mayor a 0."; return; }
                Actual.Subtotal = Actual.Cantidad * Actual.Precio_U;
                Actual = IVentas_Peliculas!.Guardar(Actual!);
                if (Actual.Id == 0) { ViewData["Mensaje"] = "No se pudo guardar. Verifique los datos."; CargarListas(); return; }
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }
        public IActionResult OnPostBtPDF()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(session)) return Redirect("/");

            CargarListas();
            Lista = IVentas_Peliculas!.Consultar();

            using var ms = new MemoryStream();
            var doc = new Document(PageSize.A4.Rotate(), 30, 30, 40, 30);
            PdfWriter.GetInstance(doc, ms);
            doc.Open();

            var titulo = new Paragraph("Reporte de Ventas Películas",
                new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 15;
            doc.Add(titulo);

            doc.Add(new Paragraph($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}",
                new Font(Font.FontFamily.HELVETICA, 9)) { SpacingAfter = 10 });

            var tabla = new PdfPTable(6) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 1, 2, 3, 1, 2, 2 });

            BaseColor gris = new BaseColor(52, 58, 64);
            Font fEnc = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD, BaseColor.WHITE);
            tabla.AddCell(new PdfPCell(new Phrase("ID", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Venta", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Película", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Cant.", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Precio U.", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Subtotal", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });

            Font fCelda = new Font(Font.FontFamily.HELVETICA, 9);
            foreach (var e in Lista!)
            {
                var pel = ListaPeliculas?.FirstOrDefault(p => p.Id == e.Peliculas)?.Nombre ?? e.Peliculas.ToString();
                tabla.AddCell(e.Id.ToString());
                tabla.AddCell("Venta #" + e.Ventas);
                tabla.AddCell(pel);
                tabla.AddCell(e.Cantidad.ToString());
                tabla.AddCell(e.Precio_U.ToString("C0"));
                tabla.AddCell(e.Subtotal.ToString("C0"));
            }

            doc.Add(tabla);
            doc.Close();

            return File(ms.ToArray(), "application/pdf", "Reporte_de_Ventas_Películas.pdf");
        }

    }
}
