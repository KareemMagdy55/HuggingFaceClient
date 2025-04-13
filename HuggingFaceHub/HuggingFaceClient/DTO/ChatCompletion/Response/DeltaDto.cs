using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.ChatCompletion.Response;

public class DeltaDto
{
    [JsonPropertyName("token_id")]
    public int TokenId { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("tool_calls")]
    public object ToolCalls { get; set; }
}
