using System.Collections.Generic;
using System.Text.Json.Serialization;
using HuggingFaceClient.Service;

namespace HuggingFaceClient.DTO.ChatCompletion.Response
{
    ///


    /// Represents a response from the chat completion operation.
    ///

    public class ChatCompletionResponseDto
    {
        ///

        /// Collection of available chat choices.
        ///

        [JsonPropertyName("choices")]
        public List<ChatChoiceDto> Choices { get; set; } = new();

        /// <summary>
        /// Details about the resource usage during the chat completion operation.
        /// </summary>
        [JsonPropertyName("usage")]
        public UsageDto? Usage { get; set; }
    }
}