using HuggingFaceClient.Utilities;

namespace HuggingFaceClient.Service {
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
    ///       var response = huggingFaceClientService.RequestChatCompletionAsync(
    /// new ChatCompletionRequestDto() {
    ///        Model = "Qwen/Qwen2.5-Coder-32B-Instruct",
    ///        Messages = [
    ///            new MessageDto() {
    ///                Role = ChatRoles.User,
    ///                Content = "HELLO"
    ///            }
    ///        ]
    ///    }
    ///   );

    /// Console.WriteLine(response.Result?.Choices[0].Message);
/// }

/// </code>
/// </remarks>
public class HuggingFaceServiceOrchestrator {
  
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