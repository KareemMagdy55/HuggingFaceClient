using HuggingFaceClient.DTO.FeatureExtraction.Request;
using HuggingFaceClient.DTO.FeatureExtraction.Response;
using HuggingFaceClient.Service;

namespace HuggingFaceClient.Builders
{
    /// <summary>
    /// A builder class to configure and send feature extraction requests to the Hugging Face API.
    /// 
    /// This builder provides a fluent interface for configuring the <see cref="FeatureExtractionRequestDto"/>
    /// and sending it using <see cref="HuggingFaceServiceOrchestrator.FeatureExtractionService"/>.
    /// </summary>
    public class FeatureExtractionRequestBuilder
    {
        private readonly FeatureExtractionRequestDto _request = new();

        private readonly HuggingFaceServiceOrchestrator _huggingFaceServiceOrchestrator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureExtractionRequestBuilder"/> class.
        /// </summary>
        /// <param name="huggingFaceServiceOrchestrator">The service orchestrator that handles API calls.</param>
        public FeatureExtractionRequestBuilder(HuggingFaceServiceOrchestrator huggingFaceServiceOrchestrator)
        {
            _huggingFaceServiceOrchestrator = huggingFaceServiceOrchestrator;
        }

        /// <summary>
        /// Sets the input data to be used for feature extraction.
        /// </summary>
        /// <param name="inputs">The input object (e.g., text, sentence, etc.).</param>
        /// <returns>The builder instance.</returns>
        public FeatureExtractionRequestBuilder WithInputs(object inputs)
        {
            _request.Inputs = inputs;
            return this;
        }

        /// <summary>
        /// Sets whether the extracted features should be normalized.
        /// </summary>
        /// <param name="normalize">True to normalize, false otherwise.</param>
        /// <returns>The builder instance.</returns>
        public FeatureExtractionRequestBuilder WithNormalize(bool normalize)
        {
            _request.Normalize = normalize;
            return this;
        }

        /// <summary>
        /// Sets the optional prompt name to use for extraction.
        /// </summary>
        /// <param name="promptName">The name of the prompt.</param>
        /// <returns>The builder instance.</returns>
        public FeatureExtractionRequestBuilder WithPromptName(string promptName)
        {
            _request.PromptName = promptName;
            return this;
        }

        /// <summary>
        /// Enables or disables truncation of the input.
        /// </summary>
        /// <param name="truncate">True to truncate input if too long.</param>
        /// <returns>The builder instance.</returns>
        public FeatureExtractionRequestBuilder WithTruncate(bool truncate)
        {
            _request.Truncate = truncate;
            return this;
        }

        /// <summary>
        /// Sets the truncation direction to use if truncation is enabled.
        /// </summary>
        /// <param name="truncationDirection">e.g., "left" or "right".</param>
        /// <returns>The builder instance.</returns>
        public FeatureExtractionRequestBuilder WithTruncationDirection(string truncationDirection)
        {
            _request.TruncationDirection = truncationDirection;
            return this;
        }

        /// <summary>
        /// Sends the feature extraction request and returns the response.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the extracted features.</returns>
        public async Task<FeatureExtractionResponseDto?> SendAsync()
        {
            return await _huggingFaceServiceOrchestrator.FeatureExtractionService.ExtractFeaturesAsync(_request);
        }
    }
}
