using HuggingFaceClient.DTO.FeatureExtraction.Request;
using HuggingFaceClient.DTO.FeatureExtraction.Response;

namespace HuggingFaceClient.Service
{
    /// <summary>
    /// Provides functionality to extract feature representations from input data
    /// using Hugging Face models via the Hugging Face API.
    /// </summary>
    public class FeatureExtractionService
    {
        /// <summary>
        /// Sends a feature extraction request to the Hugging Face API and returns the model's feature representation.
        /// </summary>
        /// <param name="request">
        /// A <see cref="FeatureExtractionRequestDto"/> object containing input data and model parameters.
        /// </param>
        /// <returns>
        /// A <see cref="FeatureExtractionResponseDto"/> containing the extracted features,
        /// or <c>null</c> if the request fails.
        /// </returns>
       
        public async Task<FeatureExtractionResponseDto?> ExtractFeaturesAsync(FeatureExtractionRequestDto request)
        {
            return await HttpRequestService._PostRequestAsync<FeatureExtractionRequestDto, FeatureExtractionResponseDto>(request);
        }
    }
}