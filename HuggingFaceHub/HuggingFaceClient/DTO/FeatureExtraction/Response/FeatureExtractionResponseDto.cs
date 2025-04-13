using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.FeatureExtraction.Response;

public class FeatureExtractionResponseDto {
    
    public object[]? Features { get; set; }
}