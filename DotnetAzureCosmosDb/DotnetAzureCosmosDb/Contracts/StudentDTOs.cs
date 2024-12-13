using Newtonsoft.Json;

namespace DotnetAzureCosmosDb.Contracts
{

    public record CreateStudentDto
    {
        [JsonProperty(PropertyName = "name")]
        public required string Name { get; init; }

        [JsonProperty(PropertyName = "email")]
        public required string Email { get; init; }

        [JsonProperty(PropertyName = "age")]
        public int Age { get; init; }
    }


    public record UpdateStudentDto
    {

        public required string Name { get; init; }
        [JsonProperty(PropertyName = "email")]
        public required string Email { get; init; }
        [JsonProperty(PropertyName = "age")]
        public int Age { get; init; }
    }


}
