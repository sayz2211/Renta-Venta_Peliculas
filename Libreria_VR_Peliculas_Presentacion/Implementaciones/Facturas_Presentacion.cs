
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;
using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class Facturas_Presentacion : IFacturas_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/Facturas";

        public List<Facturas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarFacturas";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Facturas>();
            return JsonConvert.DeserializeObject<List<Facturas>>(respuesta["Valor"].ToString()!)!;
        }

        public Facturas Guardar(Facturas entidad)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarFactura";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();

            try
            {
                var task = iComunicaciones.EjecutarPost(datos);
                task.Wait();
                var respuesta = task.Result;

                if (respuesta.ContainsKey("Valor"))
                    return JsonConvert.DeserializeObject<Facturas>(respuesta["Valor"].ToString()!)!;
            }
            catch
            {
           
            }
            return entidad;
        }
    }
}
