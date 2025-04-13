using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.ChatCompletion.Response
{
    ///


    /// Represents a single choice in a streaming chat completion response.
    ///

    public class ChatStreamChoiceDto
    {
        ///

        /// The index of this chat stream choice.
        ///

        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>
        /// The text output related to this choice.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        /// Supplemental log probability information for the text output.
        /// </summary>
        [JsonPropertyName("logprobs")]
        public object Logprobs { get; set; }

        /// <summary>
        /// The reason why this chat completion stream finished.
        /// </summary>
        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; set; }

        /// <summary>
        /// Additional seed data used in the generation process.
        /// </summary>
        [JsonPropertyName("seed")]
        public object Seed { get; set; }

        /// <summary>
        /// Represents delta changes or incremental updates associated with the output.
        /// </summary>
        [JsonPropertyName("delta")]
        public DeltaDto Delta { get; set; }
    }
}