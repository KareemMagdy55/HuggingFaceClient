using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.ChatCompletion.Response
{
    ///


    /// Represents a choice option in the chat completion response.
    ///

    public class ChatChoiceDto
    {
        ///

        /// The index corresponding to a particular chat choice.
        ///

        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>
        /// The message returned for the chat choice.
        /// </summary>
        [JsonPropertyName("message")]
        public MessageDto Message { get; set; } = new();

        /// <summary>
        /// A description of why the chat completion finished.
        /// </summary>
        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; set; } = string.Empty;
    }
}