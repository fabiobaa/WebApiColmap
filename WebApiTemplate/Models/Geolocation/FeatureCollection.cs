using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiColmap.Models.Geolocation
{
    public class FeatureCollection
    {
        public string Type { get; set; }
        public List<Feature> Features { get; set; }
    }
}