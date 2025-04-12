using System.Text.Json.Serialization;

namespace HuggingFaceHub.DTO.FeatureExtraction.Response;

public class FeatureExtractionResponseDto {
    
    public object[]? Features { get; set; }
}