using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.ChatCompletion.Response
{
    ///


    /// Contains information about token usage during chat completion.
    ///

    public class UsageDto
    {
        ///

        /// Indicates the number of tokens in the prompt.
        ///

        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }

        /// <summary>
        /// Indicates the number of tokens generated in the completion.
        /// </summary>
        [JsonPropertyName("completion_tokens")]
        public int CompletionTokens { get; set; }

        /// <summary>
        /// Represents the total number of tokens in the request (prompt and completion).
        /// </summary>
        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }
}