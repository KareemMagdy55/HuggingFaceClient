using HuggingFaceClient.Service;
using HuggingFaceClient.Utilities;

/// <summary>
/// A lightweight client for interacting with Hugging Face Spaces via HTTP requests.
/// 
/// This class provides an abstraction layer to configure the API base URL for a specific Hugging Face Space 
/// and execute typed requests using a generic <see cref="RequestAsync{TRequest, TResponse}"/> method.
/// </summary>
public class HfSpaceClient {
    /// <summary>
    /// Initializes a new instance of the <see cref="HfSpaceClient"/> class.
    /// This sets the base URL for all subsequent HTTP requests to a specific Hugging Face Space.
    /// </summary>
    /// <param name="spaceApiUrl">The base URL of the Hugging Face Space (e.g., https://space-name.hf.space).</param>
    public HfSpaceClient(string spaceApiUrl) {
        HuggingFaceGlobalConfig.ApiBaseUrl = spaceApiUrl;
    }

    /// <summary>
    /// Sends an HTTP Post request to the configured Hugging Face Space API and deserializes the response.
    /// </summary>
    /// <typeparam name="TRequest">The request DTO type used as the POST body.</typeparam>
    /// <typeparam name="TResponse">The expected response DTO type.</typeparam>
    /// <param name="requestDto">An instance of the request DTO to be serialized and sent.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, containing the deserialized response DTO,
    /// or <c>null</c> if the request failed or returned an empty response.
    /// </returns>
    public async Task<TResponse?> PostRequestAsync<TRequest, TResponse>(TRequest requestDto)
        where TRequest : class
        where TResponse : class
        =>
            await HttpRequestService._PostRequestAsync<TRequest, TResponse>(requestDto); 
    /// <summary>
    /// Sends an HTTP Get request to the configured Hugging Face Space API and deserializes the response.
    /// </summary>
    /// <typeparam name="TRequest">The request DTO type used as the POST body.</typeparam>
    /// <typeparam name="TResponse">The expected response DTO type.</typeparam>
    /// <param name="requestDto">An instance of the request DTO to be serialized and sent.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, containing the deserialized response DTO,
    /// or <c>null</c> if the request failed or returned an empty response.
    /// </returns>
    public async Task<TResponse?> GetRequestAsync<TRequest, TResponse>(TRequest requestDto)
        where TRequest : class
        where TResponse : class
        =>
            await HttpRequestService._GetRequestAsync<TRequest, TResponse>(requestDto);
}