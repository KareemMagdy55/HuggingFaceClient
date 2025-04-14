using HuggingFaceClient.DTO.FeatureExtraction.Request;
using HuggingFaceClient.DTO.FeatureExtraction.Response;
using HuggingFaceClient.Service;

namespace HuggingFaceClient.Builders {
    public class FeatureExtractionRequestBuilder {
        private readonly FeatureExtractionRequestDto _request = new();

        private readonly HuggingFaceServiceOrchestrator _huggingFaceServiceOrchestrator;

        public FeatureExtractionRequestBuilder(HuggingFaceServiceOrchestrator huggingFaceServiceOrchestrator) {
            _huggingFaceServiceOrchestrator = huggingFaceServiceOrchestrator;
        }

        public FeatureExtractionRequestBuilder WithInputs(object inputs) {
            _request.Inputs = inputs;
            return this;
        }

        public FeatureExtractionRequestBuilder WithNormalize(bool normalize) {
            _request.Normalize = normalize;
            return this;
        }

        public FeatureExtractionRequestBuilder WithPromptName(string promptName) {
            _request.PromptName = promptName;
            return this;
        }

        public FeatureExtractionRequestBuilder WithTruncate(bool truncate) {
            _request.Truncate = truncate;
            return this;
        }

        public FeatureExtractionRequestBuilder WithTruncationDirection(string truncationDirection) {
            _request.TruncationDirection = truncationDirection;
            return this;
        }

        public async Task<FeatureExtractionResponseDto?> SendAsync() {
            return await _huggingFaceServiceOrchestrator.FeatureExtractionService.ExtractFeaturesAsync(_request);
        }
    }
}