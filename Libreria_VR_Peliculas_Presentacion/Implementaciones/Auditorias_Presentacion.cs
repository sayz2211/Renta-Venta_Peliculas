
using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class Auditorias_Presentacion : IAuditorias_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/Auditorias";

        public List<Auditorias> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarAuditorias";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Auditorias>();
            return JsonConvert.DeserializeObject<List<Auditorias>>(respuesta["Valor"].ToString()!)!;
        }

        public Auditorias Guardar(Auditorias entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardó");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarAuditoria";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Auditorias();
            return JsonConvert.DeserializeObject<Auditorias>(respuesta["Valor"].ToString()!)!;
        }
    }
}
