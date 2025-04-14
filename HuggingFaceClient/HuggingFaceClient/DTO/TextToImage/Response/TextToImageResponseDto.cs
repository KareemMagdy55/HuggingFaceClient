using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.TextToImage.Response
{
    ///


    /// Represents the response returned after processing a text-to-image request.
    ///

    public class TextToImageResponseDto
    {
        ///

        /// A unique identifier for the text-to-image response.
        ///

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Specifies the type or category of the returned object.
        /// </summary>
        [JsonPropertyName("object")]
        public string Object { get; set; }

        /// <summary>
        /// Indicates the model used for generating the image.
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// Contains a collection of data chunks that include generated image details.
        /// </summary>
        [JsonPropertyName("data")]
        public List<DataChunkDto> Data { get; set; }
    }
}