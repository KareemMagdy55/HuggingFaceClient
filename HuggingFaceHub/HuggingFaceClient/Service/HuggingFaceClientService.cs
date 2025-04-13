using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using HuggingFaceClient.Utilities;
using HuggingFaceClient.DTO.ChatCompletion;
using HuggingFaceClient.DTO.ChatCompletion.Response;
using HuggingFaceClient.DTO.FeatureExtraction.Request;
using HuggingFaceClient.DTO.FeatureExtraction.Response;

namespace HuggingFaceClient.Service;

public class HuggingFaceClientService {

    public HuggingFaceClientService(string apiToken, string apiBaseUrl) {
        HuggingFaceGlobalConfig.ApiToken = apiToken;
        HuggingFaceGlobalConfig.ApiBaseUrl = apiBaseUrl;
    }
    public ChatCompletionService ChatCompletionService { get; } = new ChatCompletionService();
    public FeatureExtractionService FeatureExtractionService { get; } = new FeatureExtractionService();
    public TextToImageService TextToImageService { get; } = new TextToImageService();
}