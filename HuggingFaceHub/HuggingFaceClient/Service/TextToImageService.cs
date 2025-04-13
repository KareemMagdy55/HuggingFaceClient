using HuggingFaceClient.DTO.TextToImage;
using HuggingFaceClient.DTO.TextToImage.Response;

namespace HuggingFaceClient.Service;

///


/// Service for converting Text to image using the HuggingFace API.
///
public class TextToImageService {
    /// <summary>
    /// Returns a <see cref="TextToImageResponseDto"/>, or null if fails.
    /// </summary>
    public async Task<TextToImageResponseDto?> ConvertTextToImageAsync(TextToImageRequestDto textToImageRequest) =>
        await HttpRequestService._RequestAsync<TextToImageRequestDto, TextToImageResponseDto>(
            textToImageRequest);
}