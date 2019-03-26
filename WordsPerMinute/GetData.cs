using System.Collections;
using System.IO;
using Newtonsoft.Json;


namespace WordsPerMinute
{
    class GetData : IDataStorage
    { 
        public T LoadObject<T>(string key)
        {
            string json = File.ReadAllText("key.json");
            var word = JsonConvert.DeserializeObject<T>(json);
            return word;
        }
    }
}
