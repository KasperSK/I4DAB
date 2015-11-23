using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn4JSONDal
{
    /*
    Ved at se på en lejlighed (appartment) kan man f.eks. tilgå en varmesensors værdi (value) og regulerer rediatoren efter den værdi. 
    */
    public class GDLJsonCharacteristic
    {
        public DateTime timestamp { get; set; }
        public List<GDLJsonSensorCharacteristic> sensorCharacteristic { get; set; }
        public List<GDLJsonAppartmentCharacteristic> appartmentCharacteristic { get; set; }
        public int value { get; set; }
    }

    public class GDLJsonSensorCharacteristic
    {

        public int sensorId { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public string externalRef { get; set; }
        public string calibrationEquation { get; set; }
        public string calibrationCoeff { get; set; }
        public string calibrationDate { get; set; }

    }

    public class GDLJsonAppartmentCharacteristic
    {

        public int appartmentId { get; set; }
        public int floor { get; set; }
        public int no { get; set; }
        public float size { get; set; }
    }

    public class GDLJsonDal
    {
         
    }
}
