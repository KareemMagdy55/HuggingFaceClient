using System.Collections.Generic;
using System.Text.Json.Serialization;
using HuggingFaceClient.DTO.ChatCompletion.Response;

namespace HuggingFaceClient.DTO.ChatCompletion
{
    ///


    /// Represents a streaming response from a chat completion operation.
    ///

    public class ChatCompletionStreamResponseDto
    {
        ///

        /// Unique identifier for this streaming response.
        ///

        [JsonPropertyName("id")]
        public string Id { get; set; }

        
        /// <summary>
        /// Indicates the type of object returned.
        /// </summary>
        [JsonPropertyName("object")]
        public string ObjectType { get; set; }

        /// <summary>
        /// The timestamp (in Unix time) marking when the response was created.
        /// </summary>
        [JsonPropertyName("created")]
        public long Created { get; set; }

        /// <summary>
        /// List of choices provided in the streaming response.
        /// </summary>
        [JsonPropertyName("choices")]
        public List<ChatStreamChoiceDto> Choices { get; set; }

        /// <summary>
        /// The identifier or name of the model used for generating the response.
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// Provides additional usage information; typically includes resource consumption details.
        /// </summary>
        [JsonPropertyName("usage")]
        public object Usage { get; set; }
    }
}