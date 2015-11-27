using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonDataAccesLayer.Models;
using Newtonsoft.Json;

namespace JsonDataAccesLayer.Serializer
{
    public class GdlSerializer
    {
        private JsonSerializer _jsonSerializer;

        public GdlSerializer()
        {
            _jsonSerializer = new JsonSerializer();
        }

        public GdlMeasurements DeSerializeJsonReadings(string json)
        {
            return JsonConvert.DeserializeObject<GdlMeasurements>(json);
        }
    }
}
