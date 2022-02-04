using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiColmap.Models.Geolocation
{
    public class Feature
    {        
        public string Type { get; set; }
        public Properties Properties { get; set; }
        public Geometry Geometry { get; set; }
    }
}