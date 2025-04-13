using HuggingFaceClient.DTO.FeatureExtraction.Request;
using HuggingFaceClient.DTO.FeatureExtraction.Response;

namespace HuggingFaceClient.Service
{
    ///


    /// Service for extracting features using the HuggingFace API.
    ///

    public class FeatureExtractionService
    {
        ///
            
        /// <summary>
        /// Returns a <see cref="FeatureExtractionResponseDto"/>, or null if the extraction fails.
        /// </summary>
        public async Task<FeatureExtractionResponseDto?> ExtractFeaturesAsync(FeatureExtractionRequestDto request)
        {
            return await HttpRequestService._RequestAsync<FeatureExtractionRequestDto, FeatureExtractionResponseDto>(request);
        }
    }
}