using System.Text.Json.Serialization;
using HuggingFaceClient.DTO.ChatCompletion.Response;

namespace HuggingFaceClient.DTO.ChatCompletion;

public class ChatCompletionStreamResponseDto {
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("object")]
    public string ObjectType { get; set; }

    [JsonPropertyName("created")]
    public long Created { get; set; }

    [JsonPropertyName("choices")]
    public List<StreamChoiceDto> Choices { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("usage")]
    public object Usage { get; set; }
}



