using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApiColmap.Clases;
using WebApiColmap.Data_Access.Entity_Framework;
using WebApiColmap.Models.Departamento;


namespace WebApiColmap.Controllers
{
    //[Authorize]
    [RoutePrefix("api/ubicaciones")]
    public class UbicacionesController : ApiController
    {
        readonly DataBaseEntities1 model1;
        private readonly string path = HttpContext.Current.Request.MapPath("~" + "/Logs");

        //Objeto Log
        readonly Log oLog;


        public UbicacionesController()
        {
            this.model1 = new DataBaseEntities1();
            this.oLog = new Log(path);
        }

        /// <summary>
        /// Metodo encargado de consultar los departamentos
        /// </summary>
        /// <returns>departamento</returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var departamentos = await model1.map_tblDicDepartamentos
                    .Where(x => x.dide_estado == true)
                    .Select(x => new Departamento()
                    {
                        Id = x.dide_id_pk,
                        Nombre = x.dide_nombre,
                        Estado = x.dide_estado
                    }).OrderBy(x => x.Nombre).ToListAsync();
                return Ok(departamentos);
            }
            catch (Exception ex)
            {
                oLog.Add("Error al consulatar los departamentos Exception: " + ex);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }
    }
}
