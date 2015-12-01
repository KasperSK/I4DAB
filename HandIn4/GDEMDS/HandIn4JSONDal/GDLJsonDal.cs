using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn4JSONDal
{
    /*
    Ved at se på en lejlighed (appartment) kan man f.eks. tilgå en varmesensors værdi (value) og regulerer rediatoren efter den værdi. 
    */
    public class GDLMeassurement
    {
        public int sensorId { get; set; }

        public int appartmentId { get; set; }

        public DateTime timestamp { get; set; }
       
        public int value { get; set; }

        public GDLAppartmentCharacteristic Appartment { get; set; }
        public GDLSensorCharacteristic Sensor { get; set; }
    }

    public class GDLSensorCharacteristic
    {
        public GDLSensorCharacteristic()
        {
            Meassurements = new List<GDLMeassurement>();
        }

        public int sensorId { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public string externalRef { get; set; }
        public string calibrationEquation { get; set; }
        public string calibrationCoeff { get; set; }
        public string calibrationDate { get; set; }
        public virtual ICollection<GDLMeassurement> Meassurements { get; set; }
    }

    public class GDLAppartmentCharacteristic
    {
        public GDLAppartmentCharacteristic()
        {
            Meassurements = new List<GDLMeassurement>();
        }

        public int appartmentId { get; set; }
        public int floor { get; set; }
        public int no { get; set; }
        public float size { get; set; }
        public virtual ICollection<GDLMeassurement> Meassurements { get; set; }
    }

}
