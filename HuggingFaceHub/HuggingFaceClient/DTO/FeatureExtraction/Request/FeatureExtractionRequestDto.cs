using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.FeatureExtraction.Request;

public class FeatureExtractionRequestDto {
    [JsonPropertyName("inputs")]
    public object Inputs { get; set; } = new();

    [JsonPropertyName("normalize")]
    public bool Normalize { get; set; } = false;

    [JsonPropertyName("prompt_name")]
    public string? PromptName { get; set; }

    [JsonPropertyName("truncate")]
    public bool? Truncate { get; set; }

    [JsonPropertyName("truncation_direction")]
    public string? TruncationDirection { get; set; }
}