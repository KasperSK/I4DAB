using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandIn4JSONDal;

namespace GDLProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new GDL())
            {
                var sensor = new GDLSensorCharacteristic()
                {
                    calibrationCoeff = "jsdk",
                    calibrationDate = "Date",
                    calibrationEquation = "Equation",
                    description = "warm",
                    externalRef = "ref",
                    unit = "unit"
                };

                var Appartment = new GDLAppartmentCharacteristic() { floor = 4, no = 3, size = 42 };

                var Messurment = new GDLMeassurement() { value = 35452, timestamp = DateTime.Now };

                Messurment.appartmentCharacteristic.Add(Appartment);
                Messurment.sensorCharacteristic.Add(sensor);

                db.Meassurements.Add(Messurment);

                db.SaveChanges();
            }
            
        }
    }
}
