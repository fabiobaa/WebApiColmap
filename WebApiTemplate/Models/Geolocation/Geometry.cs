using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiColmap.Models.Geolocation
{
    public class Geometry
    {
        public string Type { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}