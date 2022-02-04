using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApiColmap.Clases;
using WebApiColmap.Data_Access.Entity_Framework;
using WebApiColmap.Models.Tamano;

namespace WebApiColmap.Controllers
{

    //[Authorize]
    [RoutePrefix("api/tamanos")]
    public class TamanosController : ApiController
    {
        readonly DataBaseEntities1 model1;
        private readonly string path = HttpContext.Current.Request.MapPath("~" + "/Logs");

        //Objeto Log
        readonly Log oLog;


        public TamanosController()
        {
            this.model1 = new DataBaseEntities1();
            this.oLog = new Log(path);
        }

        /// <summary>
        /// Controlador encargado de traer el diccionario de tamaños
        /// </summary>
        /// <returns>tamanos</returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var tamanos = await model1.map_tblDicTamanos
                    .Where(x => x.ta_estado == true)
                    .Select(x => new Tamano()
                    {
                        Id = x.ta_id_pk,
                        TamanoValor = x.ta_tamano,
                        Estado = x.ta_estado
                    }).ToListAsync();
                return Ok(tamanos);
            }
            catch (Exception ex)
            {
                oLog.Add("Error al consulatar los tamaños Exception: " + ex);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

    }
}
