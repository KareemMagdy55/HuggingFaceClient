using HuggingFaceClient.DTO.ChatCompletion;
using HuggingFaceClient.DTO.ChatCompletion.Response;

namespace HuggingFaceClient.Service;

public class ChatCompletionService {
    public async Task<ChatCompletionResponseDto?> CreateChatAsync(ChatCompletionRequestDto chatCompletionRequestDto) {
        chatCompletionRequestDto.Stream = false;
        return await HttpRequestService._RequestAsync<ChatCompletionRequestDto, ChatCompletionResponseDto>(
            chatCompletionRequestDto);
    }

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