using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Libreria_VR_Peliculas.Entidades;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class Rentas_PeliculasHTMLModel : PageModel
    {
        private IRentas_Peliculas_Presentacion? IRentasPelis;
        private IRentas_Presentacion? IRentas;
        private IPeliculas_Presentacion? IPeliculas;

        [BindProperty] public List<Rentas_Peliculas>? Lista { get; set; }
        [BindProperty] public Rentas_Peliculas? Actual { get; set; }
        public List<Rentas>? ListaRentas { get; set; }
        public List<Peliculas>? ListaPeliculas { get; set; }

        public Rentas_PeliculasHTMLModel()
        {
            IRentasPelis = new Rentas_Peliculas_Presentacion();
            IRentas = new Rentas_Presentacion();
            IPeliculas = new Peliculas_Presentacion();
        }

        private void CargarListas()
        {
            try { ListaRentas = IRentas!.Consultar(); } catch { ListaRentas = new List<Rentas>(); }
            try { ListaPeliculas = IPeliculas!.Consultar(); } catch { ListaPeliculas = new List<Peliculas>(); }
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario"))) { HttpContext.Response.Redirect("/"); return; }
            CargarListas();
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try { CargarListas(); Lista = IRentasPelis!.Consultar(); Actual = null; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
     
            Actual = new Rentas_Peliculas
            {
                Cantidad = 1,
                Dias = 1,
                Precio_Dia = 0,
                Subtotal = 0,
                Rentas = 0 
            };
            Lista = null;
        }
        public void OnPostBtGuardar()
        {
            try
            {
                CargarListas();
                if (Actual == null) return;

              
                if (Actual.Rentas == 0 || Actual.Rentas == null) throw new Exception("Debe vincular una Renta válida.");
                if (Actual.Peliculas == 0 || Actual.Peliculas == null) throw new Exception("Debe seleccionar una Película.");
                if (Actual.Cantidad <= 0) Actual.Cantidad = 1;
                if (Actual.Dias <= 0) Actual.Dias = 1;

                if (Actual.Subtotal <= 0)
                {
                    Actual.Subtotal = Actual.Cantidad * Actual.Dias * Actual.Precio_Dia;
                }

                Actual = IRentasPelis!.Guardar(Actual!);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; CargarListas(); }
        }
        public IActionResult OnPostBtPDF()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(session)) return Redirect("/");

            CargarListas();
            Lista = IRentasPelis!.Consultar();

            using var ms = new MemoryStream();
            var doc = new Document(PageSize.A4.Rotate(), 30, 30, 40, 30);
            PdfWriter.GetInstance(doc, ms);
            doc.Open();

            var titulo = new Paragraph("Reporte de Rentas Películas",
                new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 15;
            doc.Add(titulo);

            doc.Add(new Paragraph($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}",
                new Font(Font.FontFamily.HELVETICA, 9)) { SpacingAfter = 10 });

            var tabla = new PdfPTable(7) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 1, 2, 3, 1, 1, 2, 2 });

            BaseColor gris = new BaseColor(52, 58, 64);
            Font fEnc = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD, BaseColor.WHITE);
            tabla.AddCell(new PdfPCell(new Phrase("ID", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Renta", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Película", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Cant.", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Días", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Precio/Día", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Subtotal", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });

            Font fCelda = new Font(Font.FontFamily.HELVETICA, 9);
            foreach (var e in Lista!)
            {
                var pel = ListaPeliculas?.FirstOrDefault(p => p.Id == e.Peliculas)?.Nombre ?? e.Peliculas.ToString();
                tabla.AddCell(e.Id.ToString());
                tabla.AddCell("Renta #" + e.Rentas);
                tabla.AddCell(pel);
                tabla.AddCell(e.Cantidad.ToString());
                tabla.AddCell(e.Dias.ToString());
                tabla.AddCell(e.Precio_Dia.ToString("C0"));
                tabla.AddCell(e.Subtotal.ToString("C0"));
            }

            doc.Add(tabla);
            doc.Close();

            return File(ms.ToArray(), "application/pdf", "Reporte_de_Rentas_Películas.pdf");
        }

    }
}