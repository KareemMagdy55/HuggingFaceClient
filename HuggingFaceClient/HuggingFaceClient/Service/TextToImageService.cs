using HuggingFaceClient.DTO.TextToImage;
using HuggingFaceClient.DTO.TextToImage.Response;

namespace HuggingFaceClient.Service
{
    /// <summary>
    /// Provides functionality to generate images from text prompts
    /// using Hugging Face text-to-image models via the API.
    /// </summary>
    public class TextToImageService
    {
        /// <summary>
        /// Sends a text-to-image generation request to the Hugging Face API.
        /// </summary>
        /// <param name="textToImageRequest">
        /// A <see cref="TextToImageRequestDto"/> object containing the text prompt and model details.
        /// </param>
        /// <returns>
        /// A <see cref="TextToImageResponseDto"/> containing the generated image data,
        /// or <c>null</c> if the request fails.
        /// </returns>
        public async Task<TextToImageResponseDto?> ConvertTextToImageAsync(TextToImageRequestDto textToImageRequest)
        {
            return await HttpRequestService._PostRequestAsync<TextToImageRequestDto, TextToImageResponseDto>(textToImageRequest);
        }
    }
}