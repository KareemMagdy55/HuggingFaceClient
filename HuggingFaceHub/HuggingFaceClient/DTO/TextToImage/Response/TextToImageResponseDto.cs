using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.TextToImage.Response;

public class TextToImageResponseDto {
    [JsonPropertyName("id")] public string Id { get; set; }
    [JsonPropertyName("object")] public string Object { get; set; }
    [JsonPropertyName("model")] public string Model { get; set; }
    [JsonPropertyName("data")] public List<DataChunkDto> Data { get; set; }
    
}