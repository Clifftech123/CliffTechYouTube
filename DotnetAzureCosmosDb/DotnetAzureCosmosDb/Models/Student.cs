using Newtonsoft.Json;

namespace DotnetAzureCosmosDb.Models
{
    public class Student
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]

        public string Name { get; set; }


        [JsonProperty(PropertyName = "email")]

        public string Email { get; set; }


        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }
    }
}
