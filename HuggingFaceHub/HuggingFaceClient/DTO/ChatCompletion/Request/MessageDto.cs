using System.Text.Json.Serialization;
using HuggingFaceClient.Utilities;

namespace HuggingFaceClient.DTO.ChatCompletion
{
    ///


    /// Represents a message in the chat conversation.
    ///

    public class MessageDto
    {
        ///

        /// Specifies the role associated with the message. Default is ChatRoles.User.
        ///

        [JsonPropertyName("role")]
        public string Role { get; set; } = ChatRoles.User;

        /// <summary>
        /// Specifies the textual content of the message.
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

       public override string ToString()
        {
            return Content;
        }
    }
}