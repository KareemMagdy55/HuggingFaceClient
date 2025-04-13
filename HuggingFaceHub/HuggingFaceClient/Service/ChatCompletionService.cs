using HuggingFaceClient.DTO.ChatCompletion;
using HuggingFaceClient.DTO.ChatCompletion.Response;

namespace HuggingFaceClient.Service;

///
/// Provides methods to interact with HuggingFace API-based Large Language Models (LLMs) for chat completions.
///
public class ChatCompletionService {
    
    /// <summary>
    /// Returns a <see cref="ChatCompletionRequestDto"/>, or null if fails.
    /// </summary>
    public async Task<ChatCompletionResponseDto?> CreateChatAsync(ChatCompletionRequestDto chatCompletionRequestDto) {
        chatCompletionRequestDto.Stream = false;
        return await HttpRequestService._RequestAsync<ChatCompletionRequestDto, ChatCompletionResponseDto>(
            chatCompletionRequestDto);
    }
    /// <summary>
    /// Returns a <see cref="ChatCompletionStreamResponseDto"/>, or null if fails.
    /// </summary>
    public async Task<List<ChatCompletionStreamResponseDto>> CreateChatStreamAsync(
        ChatCompletionRequestDto chatCompletionRequestDto) {
        chatCompletionRequestDto.Stream = true;
        List<ChatCompletionStreamResponseDto> messages = [];
        await foreach (var s in HttpRequestService
                           ._RequestStreamAsync<ChatCompletionRequestDto, ChatCompletionStreamResponseDto>(
                               chatCompletionRequestDto))
            if (s != null)
                messages.Add(s);

        return messages;
    }
}