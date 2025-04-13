using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.ChatCompletion
{
    ///


    /// Represents a request for a chat completion operation.
    ///

    public class ChatCompletionRequestDto
    {
        ///

        /// the identifier of the model to be used for chat completion.
        ///

        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// the list of messages that form the conversation context.
        /// </summary>
        [JsonPropertyName("messages")]
        public List<MessageDto> Messages { get; set; } = new List<MessageDto>();

        /// <summary>
        /// the temperature value to control randomness in the chat completion.
        /// </summary>
        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; }

        /// <summary>
        /// the top-p (nucleus sampling) parameter to adjust the token selection process.
        /// </summary>
        [JsonPropertyName("top_p")]
        public double? TopP { get; set; }

        /// <summary>
        /// the maximum number of new tokens to generate.
        /// </summary>
        [JsonPropertyName("max_new_tokens")]
        public int? MaxNewTokens { get; set; }

        /// <summary>
        /// the repetition penalty factor to discourage repeating tokens.
        /// </summary>
        [JsonPropertyName("repetition_penalty")]
        public double? RepetitionPenalty { get; set; }

        /// <summary>
        /// a boolean value indicating whether the response should be streamed.
        /// </summary>
        [JsonPropertyName("stream")]
        public bool? Stream { get; set; }
    }
}