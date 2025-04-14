using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.TextToImage.Response
{
    ///


    /// Represents a chunk of data in the text-to-image response.
    ///

    public class DataChunkDto
    {
        ///

        /// The index of the data chunk.
        ///

        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>
        /// The URL associated with the data chunk.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Timing information for the generation process.
        /// </summary>
        [JsonPropertyName("timings")]
        public TimingsDto Timings { get; set; }
    }

    /// <summary>
    /// Contains timing data related to the inference process.
    /// </summary>
    public class TimingsDto
    {
        /// <summary>
        /// Duration of the inference step in seconds.
        /// </summary>
        [JsonPropertyName("inference")]
        public double Inference { get; set; }
    }
}