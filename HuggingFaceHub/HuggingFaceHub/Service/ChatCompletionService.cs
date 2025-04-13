using HuggingFaceHub.DTO.ChatCompletion;
using HuggingFaceHub.DTO.ChatCompletion.Response;

namespace HuggingFaceHub.Service;

public class ChatCompletionService {
    // public Task<ChatCompletionResponseDto> CreateChatAsync(ChatCompletionRequestDto chatCompletionRequestDto) {
    //     
    //     
    // }

    public async Task<List<ChatCompletionStreamResponseDto>> CreateChatStreamAsync(ChatCompletionRequestDto chatCompletionRequestDto) {
        chatCompletionRequestDto.Stream = true;
        List<ChatCompletionStreamResponseDto> messages = [];
        await foreach (var s in HttpRequestService._RequestStreamAsync<ChatCompletionRequestDto,ChatCompletionStreamResponseDto>(chatCompletionRequestDto))
            if (s != null)
                messages.Add(s);

        return messages; 
    }


}