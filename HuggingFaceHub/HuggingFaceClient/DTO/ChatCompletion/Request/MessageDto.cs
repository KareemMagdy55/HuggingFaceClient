using System.Text.Json.Serialization;
using HuggingFaceClient.Utilities;

namespace HuggingFaceClient.DTO.ChatCompletion;

public class MessageDto {
    [JsonPropertyName("role")] 
    public string Role { get; set; } = ChatRoles.User;

    [JsonPropertyName("content")] 
    public string Content { get; set; } = string.Empty;

    public override string ToString() {
        return Content;
    }
}