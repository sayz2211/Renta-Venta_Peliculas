
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;
using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class Descuentos_Presentacion : IDescuentos_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/Descuentos";

        public List<Descuentos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarDescuentos";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Descuentos>();
            return JsonConvert.DeserializeObject<List<Descuentos>>(respuesta["Valor"].ToString()!)!;
        }

        public Descuentos Guardar(Descuentos entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardó");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarDescuento";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Descuentos();
            return JsonConvert.DeserializeObject<Descuentos>(respuesta["Valor"].ToString()!)!;
        }

        public Descuentos Modificar(Descuentos entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ModificarDescuento";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPut(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Descuentos();
            return JsonConvert.DeserializeObject<Descuentos>(respuesta["Valor"].ToString()!)!;
        }
    }
}
