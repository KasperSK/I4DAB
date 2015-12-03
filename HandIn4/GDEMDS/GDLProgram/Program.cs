using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HandIn4JSONDal;
using HandIn4JSONDal.Fetcher;
using HandIn4JSONDal.Parser;

namespace GDLProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new GdlSerializer<Characteristic>();
            var file = File.ReadAllText("Json/AppartmentAndSensors.json");

            var baseData = serializer.DeSerializeJsonReadings(file);

            using (var db = new GDL())
            {
                foreach (var appartmentcharacteristic in baseData.appartmentCharacteristic)
                {
                    db.Appartments.Add(new GDLAppartmentCharacteristic() {floor = appartmentcharacteristic.Floor, no = appartmentcharacteristic.No, size = appartmentcharacteristic.Size, appartmentId = appartmentcharacteristic.appartmentId});
                }

                foreach (var sensorcharacteristic in baseData.sensorCharacteristic)
                {
                    db.Sensors.Add(new GDLSensorCharacteristic() {calibrationCoeff = sensorcharacteristic.calibrationCoeff, calibrationDate = sensorcharacteristic.calibrationDate, calibrationEquation = sensorcharacteristic.calibrationEquation, description = sensorcharacteristic.description, externalRef = sensorcharacteristic.externalRef, sensorId = sensorcharacteristic.sensorId, unit = sensorcharacteristic.unit});
                }
                db.SaveChanges();
            }

            var webFetcher = new WebFetcher();
            var serialBitches = new GdlSerializer<GdlMeasurements>();

            while (true)
            {
                var reading = serialBitches.DeSerializeJsonReadings(webFetcher.GetNextJson());

                using (var db = new GDL())
                {
                    try
                    {
                        foreach (var measurement in reading.Reading)
                        {
                            db.Meassurements.Add(new GDLMeassurement()
                            {
                                appartmentId = measurement.AppartmentId,
                                sensorId = measurement.SensorId,
                                value = measurement.Value,
                                timestamp = DateTime.Parse(measurement.Timestamp)
                            });
                        }
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception thrown with " + e.Message);
                        Console.WriteLine("Inner Exception: " + e.InnerException.Message);
                    }
                }
                Console.WriteLine("Saved one");
                Thread.Sleep(1);
            }
        }
    }
}
