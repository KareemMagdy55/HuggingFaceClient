using HuggingFaceHub.DTO.ChatCompletion;
using HuggingFaceHub.DTO.FeatureExtraction.Request;
using HuggingFaceHub.Service;
using HuggingFaceHub.Utilities;

namespace HuggingFaceHub;

public class Class1 {
    public static void Main() {
        var huggingFaceClientService =
            new HuggingFaceClientService(apiToken: "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", 
                apiBaseUrl : "https://router.huggingface.co/together/v1/chat/completions");
        
        var messages = huggingFaceClientService.ChatCompletionService.CreateChatStreamAsync(
            new ChatCompletionRequestDto()
            {
                Model = "Qwen/Qwen2.5-Coder-32B-Instruct",
                Messages = [
                    new MessageDto() {
                        Role = ChatRoles.User,
                        Content = "What is weather today?"
                    }
                ]
            });
        foreach (var message in messages.Result) {
            Console.WriteLine(message.Choices[0].Delta.Content);
        }
        
    }
}