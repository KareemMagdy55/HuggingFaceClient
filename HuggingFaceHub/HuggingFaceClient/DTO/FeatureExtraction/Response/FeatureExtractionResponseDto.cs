using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.FeatureExtraction.Response
{
    ///


    /// Represents the response containing extracted features.
    ///

    public class FeatureExtractionResponseDto
    {
        ///

        /// Contains the extracted feature set.
        ///

        public object[]? Features { get; set; }
    }
}