using System.Text.Json.Serialization;

namespace HuggingFaceHub.DTO.ChatCompletion.Response;

public class ChatCompletionResponseDto {
    [JsonPropertyName("choices")]
    public List<ChatChoiceDto> Choices { get; set; } = new();

    [JsonPropertyName("usage")]
    public UsageDto? Usage { get; set; }
}