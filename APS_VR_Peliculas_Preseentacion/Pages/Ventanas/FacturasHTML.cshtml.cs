using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas_Presentacion.Implementaciones;
using Libreria_VR_Peliculas_Presentacion.Interfaces;

namespace APS_VR_Peliculas_Preseentacion.Pages
{
    public class FacturasHTMLModel : PageModel
    {
        // 1. Interfaces (Asegúrate de que estas clases existan en tu capa de Presentación)
        private IFacturas_Presentacion IFacturas = new Facturas_Presentacion();
        private IClientes_Presentacion IClientes = new Clientes_Presentacion();
        private IRentas_Presentacion IRentas = new Rentas_Presentacion();
        private IVentas_Presentacion IVentas = new Ventas_Presentacion();
        private IDescuentos_Presentacion IDescuentos = new Descuentos_Presentacion();

        [BindProperty] public List<Facturas>? Lista { get; set; }
        [BindProperty] public Facturas? Actual { get; set; }

        // Estas propiedades deben llamarse EXACTAMENTE así para que el HTML las vea
        public List<Clientes>? ListaClientes { get; set; }
        public List<Rentas>? ListaRentas { get; set; }
        public List<Ventas>? ListaVentas { get; set; }
        public List<Descuentos>? ListaDescuentos { get; set; }

        private void CargarListas()
        {
            // Cargamos los datos de la BD a las listas del modelo
            try { ListaClientes = IClientes.Consultar(); } catch { ListaClientes = new List<Clientes>(); }
            try { ListaRentas = IRentas.Consultar(); } catch { ListaRentas = new List<Rentas>(); }
            try { ListaVentas = IVentas.Consultar(); } catch { ListaVentas = new List<Ventas>(); }
            try { ListaDescuentos = IDescuentos.Consultar(); } catch { ListaDescuentos = new List<Descuentos>(); }
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario")))
            {
                HttpContext.Response.Redirect("/");
                return;
            }
            CargarListas();
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                CargarListas();
                Lista = IFacturas.Consultar();
                Actual = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = "Error al refrescar: " + ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            CargarListas();
            // Inicializamos con valores por defecto para evitar nulos en BD
            Actual = new Facturas
            {
                Fecha = DateTime.Now,
                Codigo = "FAC-" + DateTime.Now.ToString("mmss"),
                Total = 0,
                Clientes = 0 // Clave foránea según tu tabla dbo.Facturas
            };
            Lista = null;
        }

        public void OnPostBtModificar(int data)
        {
            CargarListas();
            var todas = IFacturas.Consultar();
            Actual = todas?.FirstOrDefault(x => x.Id == data);
            Lista = null;
        }

        public void OnPostBtGuardar()
        {
            try
            {
                CargarListas();
                if (Actual == null) return;

                // Validación de seguridad antes de mandar al API/BD
                if (Actual.Clientes <= 0) throw new Exception("Debe seleccionar un Cliente.");

                // Si el objeto viene del API con error de deserialización (Id=0), 
                // intentamos forzar el guardado
                var resultado = IFacturas.Guardar(Actual);

                if (resultado == null) throw new Exception("El servidor no devolvió respuesta.");

                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
                CargarListas();
            }
        }
        public IActionResult OnPostBtPDF()
        {
            var session = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(session)) return Redirect("/");

            CargarListas();
            Lista = IFacturas.Consultar();

            using var ms = new MemoryStream();
            var doc = new Document(PageSize.A4.Rotate(), 30, 30, 40, 30);
            PdfWriter.GetInstance(doc, ms);
            doc.Open();

            var titulo = new Paragraph("Reporte de Facturas",
                new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 15;
            doc.Add(titulo);

            doc.Add(new Paragraph($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}",
                new Font(Font.FontFamily.HELVETICA, 9)) { SpacingAfter = 10 });

            var tabla = new PdfPTable(5) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 1, 2, 3, 2, 2 });

            BaseColor gris = new BaseColor(52, 58, 64);
            Font fEnc = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD, BaseColor.WHITE);
            tabla.AddCell(new PdfPCell(new Phrase("ID", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Código", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Cliente", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Total", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
            tabla.AddCell(new PdfPCell(new Phrase("Fecha", fEnc)) { BackgroundColor = gris, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });

            Font fCelda = new Font(Font.FontFamily.HELVETICA, 9);
            foreach (var e in Lista!)
            {
                var cliente = ListaClientes?.FirstOrDefault(c => c.Id == e.Clientes)?.Nombre ?? e.Clientes.ToString();
                tabla.AddCell(e.Id.ToString());
                tabla.AddCell(e.Codigo ?? "");
                tabla.AddCell(cliente);
                tabla.AddCell(e.Total.ToString("C0"));
                tabla.AddCell(e.Fecha.ToString("yyyy-MM-dd"));
            }

            doc.Add(tabla);
            doc.Close();

            return File(ms.ToArray(), "application/pdf", "Reporte_de_Facturas.pdf");
        }

    }
}