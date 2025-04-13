using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.TextToImage;

public class TextToImageRequestDto {
    [JsonPropertyName("inputs")]
    public string Inputs { get; set; }
    
    [JsonPropertyName("prompt")]
    public string Prompt { get; set; }
    
    
    
    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("parameters")]
    public TextToImageParametersDto ParametersDto { get; set; }

}