using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.ChatCompletion.Response
{
    ///


    /// Provides delta information related to a token in the chat completion response.
    ///

    public class DeltaDto
    {
        ///

        /// Token identifier.
        ///

        [JsonPropertyName("token_id")]
        public int TokenId { get; set; }

        /// <summary>
        /// Role associated with the token.
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }

        /// <summary>
        /// Content change represented by the delta.
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// Details regarding external tool calls.
        /// </summary>
        [JsonPropertyName("tool_calls")]
        public object ToolCalls { get; set; }
    }
}