using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.TextToImage
{
    ///


    /// Represents a request to generate an image from a text prompt.
    ///

    public class TextToImageRequestDto
    {
        ///

        /// Contains the primary text input or description.
        ///

        [JsonPropertyName("inputs")]
        public string Inputs { get; set; }

        /// <summary>
        /// Provides the main prompt guiding the image generation process.
        /// </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// Specifies the model used for generating the image.
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// Contains additional parameters influencing the image generation behavior.
        /// </summary>
        [JsonPropertyName("parameters")]
        public TextToImageParametersDto ParametersDto { get; set; }
    }
}