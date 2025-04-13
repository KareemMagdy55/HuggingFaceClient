using HuggingFaceClient.Utilities;

namespace HuggingFaceClient.Service {
    ///
    /// Provides a unified client interface for interacting with the HuggingFace API.
    ///
    ///
    /// This service initializes the global configuration and exposes specialized services for:
    ///
    ///
    /// Chat completion operations with ChatCompletionService.
    ///
    ///
    /// Feature extraction operations with FeatureExtractionService.
    ///
    ///
    /// Text-to-image generation with TextToImageService.
    ///
    ///
    ///
    ///
    /// The following example shows how to initialize and use the HuggingFaceClientService:
    /// 
    /// // Instantiate the client service with your API token and base URL
    /// var clientService = new HuggingFaceClientService("hf_xxxx", "https://router.huggingface.co/together/v1/chat/completions");
    ///
    /// // Use the ChatCompletionService to request a chat completion
    /// var chatResult = clientService.ChatCompletionService.ExecuteChatCompletion("Hello, world!");
    ///
    /// // Use the FeatureExtractionService to perform feature extraction
    /// var features = clientService.FeatureExtractionService.ExtractFeatures(someInputData);
    ///
    /// // Use the TextToImageService to generate an image from a text prompt
    /// var imageResult = clientService.TextToImageService.GenerateImage("A beautiful sunset");
    /// 
    ///
    public class HuggingFaceClientService {
        ///
        /// Initializes a new instance of the class.
        /// Sets up the global API configuration.
        ///
        /// The API authentication token.
        /// The base URL for the HuggingFace API.
        /// 
        /// <code>
        /// Example usage:
        /// 
        /// // Set the API token and base URL before making API calls
        /// ApiToken = "hf_xxxx";
        /// ApiBaseUrl = "https://router.huggingface.co/together/v1/chat/completions";
        /// 
        /// var huggingFaceClientService =
        /// new HuggingFaceClientService(apiToken: ApiToken, apiBaseUrl : ApiBaseUrl);
        ///</code>>
        public HuggingFaceClientService(string apiToken, string apiBaseUrl) {
            HuggingFaceGlobalConfig.ApiToken = apiToken;
            HuggingFaceGlobalConfig.ApiBaseUrl = apiBaseUrl;
        }

        /// <summary>
        /// Gets the service for handling chat completion operations.
        /// </summary>
        public ChatCompletionService ChatCompletionService { get; } = new ChatCompletionService();

        /// <summary>
        /// Gets the service for performing feature extraction.
        /// </summary>
        public FeatureExtractionService FeatureExtractionService { get; } = new FeatureExtractionService();

        /// <summary>
        /// Gets the service for generating images from text prompts.
        /// </summary>
        public TextToImageService TextToImageService { get; } = new TextToImageService();
    }
}