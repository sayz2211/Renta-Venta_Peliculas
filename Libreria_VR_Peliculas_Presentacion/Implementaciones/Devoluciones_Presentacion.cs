
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;
using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class Devoluciones_Presentacion : IDevoluciones_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/Devoluciones";

        public List<Devoluciones> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarDevoluciones";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Devoluciones>();
            return JsonConvert.DeserializeObject<List<Devoluciones>>(respuesta["Valor"].ToString()!)!;
        }

        public Devoluciones Guardar(Devoluciones entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardó");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarDevolucion";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Devoluciones();
            return JsonConvert.DeserializeObject<Devoluciones>(respuesta["Valor"].ToString()!)!;
        }
    }
}
