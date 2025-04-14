using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.ChatCompletion
{
    /// <summary>
    /// Represents a request payload used to generate a chat-based completion from a language model.
    /// 
    /// This DTO includes:
    /// - <c>Model</c>: The identifier of the language model to use.
    /// - <c>Messages</c>: A list of message objects forming the chat history and context.
    /// - <c>Temperature</c>: A value (0–1) controlling randomness in the output; higher means more randomness.
    /// - <c>TopP</c>: Controls the nucleus sampling; limits choices to the most probable tokens with cumulative probability <c>top_p</c>.
    /// - <c>MaxNewTokens</c>: Specifies the maximum number of tokens to generate in the response.
    /// - <c>RepetitionPenalty</c>: Penalizes repeated phrases or tokens to improve diversity.
    /// - <c>Stream</c>: If true, the output is returned as a stream of tokens.
    /// 
    /// These properties allow fine-grained control over how the model generates and returns chat responses.
    /// </summary>
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