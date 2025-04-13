using HuggingFaceClient.DTO.TextToImage;
using HuggingFaceClient.DTO.TextToImage.Response;

namespace HuggingFaceClient.Service;

public class TextToImageService {
    public async Task<TextToImageResponseDto?> ConvertTextToImageAsync(TextToImageRequestDto textToImageRequest) =>
        await HttpRequestService._RequestAsync<TextToImageRequestDto, TextToImageResponseDto>(
            textToImageRequest);
}