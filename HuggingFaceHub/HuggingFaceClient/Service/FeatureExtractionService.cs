using HuggingFaceClient.DTO.FeatureExtraction.Request;
using HuggingFaceClient.DTO.FeatureExtraction.Response;

namespace HuggingFaceClient.Service;

public class FeatureExtractionService {
    public async Task<FeatureExtractionResponseDto?> ExtractFeaturesAsync(
        FeatureExtractionRequestDto featureExtractionRequest) =>
        await HttpRequestService._RequestAsync<FeatureExtractionRequestDto, FeatureExtractionResponseDto>(
            featureExtractionRequest);
}