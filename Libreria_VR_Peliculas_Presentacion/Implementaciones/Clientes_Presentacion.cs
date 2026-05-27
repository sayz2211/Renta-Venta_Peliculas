
using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class Clientes_Presentacion : IClientes_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/Clientes";

        public List<Clientes> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarClientes";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Clientes>();
            return JsonConvert.DeserializeObject<List<Clientes>>(respuesta["Valor"].ToString()!)!;
        }

        public Clientes Guardar(Clientes entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardó");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarCliente";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Clientes();
            return JsonConvert.DeserializeObject<Clientes>(respuesta["Valor"].ToString()!)!;
        }

        public Clientes Modificar(Clientes entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ModificarCliente";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPut(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Clientes();
            return JsonConvert.DeserializeObject<Clientes>(respuesta["Valor"].ToString()!)!;
        }

        public Clientes Eliminar(Clientes entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/EliminarCliente";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarDelete(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Clientes();
            return JsonConvert.DeserializeObject<Clientes>(respuesta["Valor"].ToString()!)!;
        }
    }
}
