using System.Text.Json.Serialization;

namespace HuggingFaceHub.DTO.ChatCompletion;

public class ChatCompletionRequestDto
{
    [JsonPropertyName("model")]
    public string Model { get; set; } 

    [JsonPropertyName("messages")]
    public List<MessageDto> Messages { get; set; } = new();

    [JsonPropertyName("temperature")]
    public double? Temperature { get; set; }

    [JsonPropertyName("top_p")]
    public double? TopP { get; set; }

    [JsonPropertyName("max_new_tokens")]
    public int? MaxNewTokens { get; set; }

    [JsonPropertyName("repetition_penalty")]
    public double? RepetitionPenalty { get; set; }

    [JsonPropertyName("stream")]
    public bool? Stream { get; set; }
}