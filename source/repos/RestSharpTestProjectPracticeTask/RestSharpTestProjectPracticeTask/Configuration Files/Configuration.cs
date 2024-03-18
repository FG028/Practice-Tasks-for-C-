using Newtonsoft.Json;

namespace RestSharpTestProjectPracticeTask.Configuration_Files
{
    public class Configuration
    {
        public string BaseUrl { get; set; }

        public static Configuration LoadFromAppSettings(string filePath = "appsettings.json")
        {
            using (var stream = File.OpenRead(filePath))
            using (var reader = new StreamReader(stream))
            {
                string jsonContent = reader.ReadToEnd();

                var config = JsonConvert.DeserializeObject<Configuration>(jsonContent);
                return config;
            }
        }
    }
}