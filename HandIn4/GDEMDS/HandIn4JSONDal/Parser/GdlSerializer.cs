using Newtonsoft.Json;

namespace HandIn4JSONDal.Parser
{
    public class GdlSerializer<T>
    {
        private JsonSerializer _jsonSerializer;

        public GdlSerializer()
        {
            _jsonSerializer = new JsonSerializer();
        }

        public T DeSerializeJsonReadings(string json) 
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}