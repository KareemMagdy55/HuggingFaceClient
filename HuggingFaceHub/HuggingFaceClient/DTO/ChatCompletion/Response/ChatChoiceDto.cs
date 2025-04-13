using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.ChatCompletion.Response;

public class ChatChoiceDto {
    [JsonPropertyName("index")] public int Index { get; set; }

    [JsonPropertyName("message")] public MessageDto Message { get; set; } = new();

    [JsonPropertyName("finish_reason")] public string FinishReason { get; set; } = string.Empty;
}