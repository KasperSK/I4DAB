using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonDataAccesLayer;
using JsonDataAccesLayer.Serializer;

namespace JsonDataAccess.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new GdlSerializer();
            var json = File.ReadAllText("TestData.json");

            var GdlMeasure = test.DeSerializeJsonReadings(json);

            foreach (var measurement in GdlMeasure.Reading)
            {
                Console.WriteLine($"{measurement.AppartmentId} {measurement.SensorId} {measurement.Value} {measurement.Timestamp}");
            }
        }
    }
}
