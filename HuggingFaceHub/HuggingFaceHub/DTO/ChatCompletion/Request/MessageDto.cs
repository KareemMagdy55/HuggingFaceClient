using HuggingFaceHub.Utilities;

namespace HuggingFaceHub.DTO.ChatCompletion;

public class MessageDto {
    public string Role { get; set; } = ChatRoles.User;
    public string Content { get; set; } = "";
}