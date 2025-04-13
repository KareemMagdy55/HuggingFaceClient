using System.Text.Json.Serialization;

namespace HuggingFaceHub.DTO.TextToImage;

public class TextToImageRequestDTO {
    [JsonPropertyName("inputs")]
    public string Inputs { get; set; }

    [JsonPropertyName("parameters")]
    public TextToImageParameters Parameters { get; set; }

}