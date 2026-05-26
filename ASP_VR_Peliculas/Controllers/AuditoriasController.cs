using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuditoriasController : ControllerBase
    {
        private IAuditorias_Negocio iAuditorias;

        public AuditoriasController()
        {
            this.iAuditorias = new Auditorias_Negocio();
        }

        [HttpGet]
        public List<Auditorias> ConsultarAuditorias()
        {
            if (this.iAuditorias == null) throw new Exception("No implementado");
            return this.iAuditorias.Consultar();
        }

        [HttpPost]
        public Auditorias GuardarAuditoria([FromBody] Auditorias entidad)
        {
            if (this.iAuditorias == null) throw new Exception("No implementado");
            return this.iAuditorias.Guardar(entidad);
        }
    }
}
