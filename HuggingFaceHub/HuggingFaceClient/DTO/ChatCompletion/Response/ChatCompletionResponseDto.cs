using System.Text.Json.Serialization;
using HuggingFaceClient.Service;

namespace HuggingFaceClient.DTO.ChatCompletion.Response;

public class ChatCompletionResponseDto {
    [JsonPropertyName("choices")]
    public List<ChatChoiceDto> Choices { get; set; } = new();

    [JsonPropertyName("usage")]
    public UsageDto? Usage { get; set; }


}