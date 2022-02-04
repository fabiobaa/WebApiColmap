using GeoJSON.Net.Geometry;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApiColmap.Clases;
using WebApiColmap.Data_Access.Entity_Framework;
using WebApiColmap.Models.Geolocation;

namespace WebApiColmap.Controllers
{
    [RoutePrefix("api/geolocations")]
    public class GeolocationsController : ApiController
    {

        private readonly string path = HttpContext.Current.Request.MapPath("~" + "/Logs");

        readonly DataBaseEntities1 model1;
        readonly Log oLog;
        readonly FeatureCollection featureCollection;
        private readonly Feature feature;
        private readonly Properties properties;
        private readonly Geometry geometry;
        private readonly Coordinates coordinates;

        public GeolocationsController()
        {
            this.oLog = new Log(path);
            this.model1 = new DataBaseEntities1();
            this.featureCollection = new FeatureCollection();
            this.feature = new Feature();
            this.properties = new Properties();
            this.geometry = new Geometry();
            this.coordinates = new Coordinates();
        }

        [HttpGet]

        public IHttpActionResult Get()
        {
            try
            {
                //geometry.Coordinates.Add();
                //geometry.Coordinates.Add(40.44356);

                Position position = new Position(51.899523, -2.124156);
                Point point = new Point(position);

                coordinates.Longitude(-79.91746);
                coordinates.Latitude(40.44356);
                geometry.Type = "Point";
                properties.Dbh = 2.5;
                properties.Departamento = "Bogota";
                feature.Type = "Feature";
                feature.Properties = properties;
                feature.Geometry = geometry;
                featureCollection.Features.Add(feature);
                featureCollection.Type = "FeatureCollection";

               
                

                string json = JsonConvert.SerializeObject(featureCollection);

                //var f = model1.map_tblCoordinates.se
                return Ok(json);

            }
            catch (Exception ex)
            {
                
               oLog.Add("Error al consulatar los departamentos Exception: " + ex);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }
    }
}