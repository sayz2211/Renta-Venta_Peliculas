using Libreria_VR_Peliculas.Entidades;
using Libreria_VR_Peliculas.Implementaciones;
using Libreria_VR_Peliculas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_VR_Peliculas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RentasController : ControllerBase
    {
        private IRentas_Negocio iRentas;

        public RentasController()
        {
            this.iRentas = new Rentas_Negocio();
        }

        [HttpGet]
        public List<Rentas> ConsultarRentas()
        {
            if (this.iRentas == null) throw new Exception("No implementado");
            return this.iRentas.Consultar();
        }
        [HttpPost]
        public ActionResult GuardarRenta([FromBody] Rentas entidad)
        {
            try
            {
                if (this.iRentas == null) throw new Exception("No implementado");
                return Ok(this.iRentas.Guardar(entidad));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
