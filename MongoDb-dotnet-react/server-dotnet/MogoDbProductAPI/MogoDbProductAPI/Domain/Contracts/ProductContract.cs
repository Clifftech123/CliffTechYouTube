using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MogoDbProductAPI.Domain.Contracts
{
    public record CreateProductDto
    {
        [Required(ErrorMessage = "Name is required")]
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Description is required")]
        [JsonPropertyName("description")]
        public string Description { get; init; }

        [Required(ErrorMessage = "Price is required")]
        [JsonPropertyName("price")]
        public double? Price { get; init; }
    }


    public record UpdateProductDto
    {
        [Required]

        [JsonPropertyName("name")]
        public string Name { get; init; }
        [Required]

        [JsonPropertyName("description")]
        public string Description { get; init; }

        [Required]


        [JsonPropertyName("price")]
        public double? Price { get; init; }
    }

    public record ProductDto
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("description")]
        public string Description { get; init; }

        [JsonPropertyName("price")]
        public double? Price { get; init; }
    }

    public record DeleteProduct
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }
    }
}
