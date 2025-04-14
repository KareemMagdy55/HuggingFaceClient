using HuggingFaceClient.Service;
using HuggingFaceClient.Utilities;

namespace HuggingFaceClient.Builders;

public class HfClient {
    /// <summary>
    /// Initializes a new instance of the <see cref="HfClient"/> class.
    /// </summary>
    /// <param name="apiToken">The Hugging Face API authentication token.</param>
    /// <param name="apiBaseUrl">The base URL of the Hugging Face API endpoint.</param>
    /// <example>
    /// <code>
    /// var service = new HdClient("hf_xxxx", "https://api-inference.huggingface.co/");
    /// </code>
    /// </example>
    public HfClient(string apiToken, string apiBaseUrl) {
        HuggingFaceGlobalConfig.ApiToken = apiToken;
        HuggingFaceGlobalConfig.ApiBaseUrl = apiBaseUrl;
    }

    private static HuggingFaceServiceOrchestrator HuggingFaceServiceOrchestrator { get; set; } =
        new HuggingFaceServiceOrchestrator();
    
    public ChatCompletionRequestBuilder Chat { get; } = new ChatCompletionRequestBuilder(HuggingFaceServiceOrchestrator);

    public FeatureExtractionRequestBuilder ExtractFeatures { get; } =
        new FeatureExtractionRequestBuilder(HuggingFaceServiceOrchestrator);

    public TextToImageRequestBuilder TextToImage { get; } =
        new TextToImageRequestBuilder(HuggingFaceServiceOrchestrator);

}