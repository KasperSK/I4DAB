using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataAccesLayer.Models
{
    public class Measurement 
    {
        public int SensorId { get; set; }
        public int AppartmentId { get; set; }
        public double Value { get; set; }
        public string Timestamp { get; set; }
    }
}
