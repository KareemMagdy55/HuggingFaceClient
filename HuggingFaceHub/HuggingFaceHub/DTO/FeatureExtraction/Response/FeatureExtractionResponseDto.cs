using System.Text.Json.Serialization;

namespace HuggingFaceHub.DTO.FeatureExtraction.Response;

public class FeatureExtractionResponseDto {
    [JsonPropertyName("features")]
    public List<List<object>> Features { get; set; } = new();
}