
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;
using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class TiposGeneros_Presentacion : ITiposGeneros_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/TiposGeneros";

        public List<TiposGeneros> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarTiposGeneros";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<TiposGeneros>();
            return JsonConvert.DeserializeObject<List<TiposGeneros>>(respuesta["Valor"].ToString()!)!;
        }

        public TiposGeneros Guardar(TiposGeneros entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardó");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarTipoGenero";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new TiposGeneros();
            return JsonConvert.DeserializeObject<TiposGeneros>(respuesta["Valor"].ToString()!)!;
        }

        public TiposGeneros Modificar(TiposGeneros entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ModificarTipoGenero";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPut(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new TiposGeneros();
            return JsonConvert.DeserializeObject<TiposGeneros>(respuesta["Valor"].ToString()!)!;
        }
    }
}
