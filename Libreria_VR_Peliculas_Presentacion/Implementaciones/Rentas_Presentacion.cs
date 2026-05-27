
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;
using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class Rentas_Presentacion : IRentas_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/Rentas";

        public List<Rentas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarRentas";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Rentas>();
            return JsonConvert.DeserializeObject<List<Rentas>>(respuesta["Valor"].ToString()!)!;
        }

        public Rentas Guardar(Rentas entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardó");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarRenta";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Rentas();
            return JsonConvert.DeserializeObject<Rentas>(respuesta["Valor"].ToString()!)!;
        }
    }
}
