
using Libreria_VR_Peliculas_Presentacion.Interfaces;
using Newtonsoft.Json;
using Libreria_VR_Peliculas.Entidades;

namespace Libreria_VR_Peliculas_Presentacion.Implementaciones
{
    public class Empleados_Presentacion : IEmpleados_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5103/Empleados";

        public List<Empleados> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarEmpleados";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Empleados>();
            return JsonConvert.DeserializeObject<List<Empleados>>(respuesta["Valor"].ToString()!)!;
        }

        public Empleados Guardar(Empleados entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardó");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarEmpleado";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Empleados();
            return JsonConvert.DeserializeObject<Empleados>(respuesta["Valor"].ToString()!)!;
        }

        public Empleados Modificar(Empleados entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ModificarEmpleado";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPut(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Empleados();
            return JsonConvert.DeserializeObject<Empleados>(respuesta["Valor"].ToString()!)!;
        }

        public Empleados Eliminar(Empleados entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/EliminarEmpleado";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarDelete(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Empleados();
            return JsonConvert.DeserializeObject<Empleados>(respuesta["Valor"].ToString()!)!;
        }
    }
}
