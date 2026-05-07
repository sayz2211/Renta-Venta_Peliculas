namespace Libreria_VR_Peliculas.Nucleo
{
    public class Configuraciones
    {
        public static string obtener(string clave)
        {
            return "server=localhost;database=db_VR_Peliculas;Integrated Security=True;TrustServerCertificate=true;";
        }
    }
}