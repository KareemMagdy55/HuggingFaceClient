using HuggingFaceClient.DTO.ChatCompletion;
using HuggingFaceClient.DTO.ChatCompletion.Response;

namespace HuggingFaceClient.Service {
    /// <summary>
    /// Provides methods to interact with Hugging Face API-based Large Language Models (LLMs) for chat completions.
    /// </summary>
    public class ChatCompletionService {
        /// <summary>
        /// Sends a non-streamed chat completion request to the Hugging Face API.
        /// </summary>
        /// <param name="chatCompletionRequestDto">
        /// The request payload containing chat parameters and messages.
        /// </param>
        /// <returns>
        /// A <see cref="ChatCompletionResponseDto"/> containing the model's reply,
        /// or <c>null</c> if the request fails.
        /// </returns>
      
        public async Task<ChatCompletionResponseDto?>
            CreateChatAsync(ChatCompletionRequestDto chatCompletionRequestDto) {
            chatCompletionRequestDto.Stream = false;

            return await HttpRequestService._RequestAsync<ChatCompletionRequestDto, ChatCompletionResponseDto>(
                chatCompletionRequestDto);
        }

        /// <summary>
        /// Sends a streamed chat completion request to the Hugging Face API.
        /// This method allows processing model responses incrementally as they arrive.
        /// </summary>
        /// <param name="chatCompletionRequestDto">
        /// The request payload configured for streaming.
        /// </param>
        /// <returns>
        /// A list of <see cref="ChatCompletionStreamResponseDto"/> representing streamed partial responses from the model.
        /// </returns>
       
        public async Task<List<ChatCompletionStreamResponseDto>> CreateChatStreamAsync(
            ChatCompletionRequestDto chatCompletionRequestDto) {
            chatCompletionRequestDto.Stream = true;
            var messages = new List<ChatCompletionStreamResponseDto>();

            await foreach (var message in HttpRequestService
                               ._RequestStreamAsync<ChatCompletionRequestDto, ChatCompletionStreamResponseDto>(
                                   chatCompletionRequestDto)) {
                if (message != null) {
                    messages.Add(message);
                }
            }

            return messages;
        }
    }
}