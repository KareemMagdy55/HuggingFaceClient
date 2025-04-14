using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.FeatureExtraction.Request
{
    ///


    /// Represents a request object for feature extraction operations.
    ///

    public class FeatureExtractionRequestDto
    {
        ///

        /// Specifies the input data for feature extraction.
        ///

        [JsonPropertyName("inputs")]
        public object Inputs { get; set; } = new();
        
        /// <summary>
        /// Indicates whether to apply normalization on the input data. Default is false.
        /// </summary>
        [JsonPropertyName("normalize")]
        public bool Normalize { get; set; } = false;

        /// <summary>
        /// Specifies an optional name for the prompt.
        /// </summary>
        [JsonPropertyName("prompt_name")]
        public string? PromptName { get; set; }

        /// <summary>
        /// Determines whether to truncate the input if it exceeds allowed length.
        /// </summary>
        [JsonPropertyName("truncate")]
        public bool? Truncate { get; set; }

        /// <summary>
        /// Specifies the direction to use for truncation, if applicable.
        /// </summary>
        [JsonPropertyName("truncation_direction")]
        public string? TruncationDirection { get; set; }
    }
}