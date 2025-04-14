using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.TextToImage
{
    ///


    /// Contains parameters for generating images from text prompts.
    ///

    public class TextToImageParametersDto
    {
        ///

        /// Specifies the guidance scale that controls the adherence of the generated image to the text prompt.
        ///

        [JsonPropertyName("guidance_scale")]
        public float? GuidanceScale { get; set; }

        /// <summary>
        /// Specifies a negative prompt that influences the image generation to avoid certain elements.
        /// </summary>
        [JsonPropertyName("negative_prompt")]
        public string NegativePrompt { get; set; }

        /// <summary>
        /// Specifies the number of inference steps to be used during image generation.
        /// </summary>
        [JsonPropertyName("num_inference_steps")]
        public int? NumInferenceSteps { get; set; }

        /// <summary>
        /// Specifies the width (in pixels) of the generated image.
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Specifies the height (in pixels) of the generated image.
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Specifies the scheduler used to manage the image generation process.
        /// </summary>
        [JsonPropertyName("scheduler")]
        public string Scheduler { get; set; }

        /// <summary>
        /// Specifies the seed value for deterministic image generation.
        /// </summary>
        [JsonPropertyName("seed")]
        public int? Seed { get; set; }
    }
}