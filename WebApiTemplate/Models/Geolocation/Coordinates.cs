using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiColmap.Models.Geolocation
{
    public class Coordinates
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}