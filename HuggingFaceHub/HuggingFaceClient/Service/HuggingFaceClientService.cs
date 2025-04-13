using HuggingFaceClient.Utilities;

namespace HuggingFaceClient.Service
{
    /// <summary>
    /// Provides a centralized and unified interface for interacting with various Hugging Face API services.
    /// </summary>
    /// <remarks>
    /// This service initializes the global API configuration and exposes specialized sub-services for:
    /// 
    /// - Chat completion operations via <see cref="ChatCompletionService"/>
    /// - Feature extraction via <see cref="FeatureExtractionService"/>
    /// - Text-to-image generation via <see cref="TextToImageService"/>
    /// 
    /// <para>
    /// Example usage:
    /// </para>
    /// <code>
    /// // Initialize the client with your Hugging Face API token and base URL
    /// var clientService = new HuggingFaceClientService(
    ///     apiToken: "hf_xxxx",
    ///     apiBaseUrl: "https://router.huggingface.co/together/v1/chat/completions"
    /// );
    ///
    /// // Use the ChatCompletionService to get a response from a prompt
    /// var chatResult = clientService.ChatCompletionService.ExecuteChatCompletion("Hello, world!");
    ///
    /// // Perform feature extraction on input data
    /// var features = clientService.FeatureExtractionService.ExtractFeatures(someInputData);
    ///
    /// // Generate an image from a text description
    /// var imageResult = clientService.TextToImageService.GenerateImage("A beautiful sunset");
    /// </code>
    /// </remarks>
    public class HuggingFaceClientService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HuggingFaceClientService"/> class.
        /// </summary>
        /// <param name="apiToken">The Hugging Face API authentication token.</param>
        /// <param name="apiBaseUrl">The base URL of the Hugging Face API endpoint.</param>
        /// <example>
        /// <code>
        /// var service = new HuggingFaceClientService("hf_xxxx", "https://api-inference.huggingface.co/");
        /// </code>
        /// </example>
        public HuggingFaceClientService(string apiToken, string apiBaseUrl)
        {
            HuggingFaceGlobalConfig.ApiToken = apiToken;
            HuggingFaceGlobalConfig.ApiBaseUrl = apiBaseUrl;
        }

        /// <summary>
        /// Gets the service responsible for handling chat completions.
        /// </summary>
        public ChatCompletionService ChatCompletionService { get; } = new ChatCompletionService();

        /// <summary>
        /// Gets the service responsible for extracting features from input data.
        /// </summary>
        public FeatureExtractionService FeatureExtractionService { get; } = new FeatureExtractionService();

        /// <summary>
        /// Gets the service responsible for generating images from textual descriptions.
        /// </summary>
        public TextToImageService TextToImageService { get; } = new TextToImageService();
    }
}
