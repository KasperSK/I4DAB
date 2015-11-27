using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataAccesLayer.Models
{
    public class GdlMeasurements
    {
        public int Version { get; set; }
        public string Timestamp { get; set; }
        public List<Measurement> Reading { get; set; }
    }
}
