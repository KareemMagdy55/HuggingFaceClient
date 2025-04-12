using HuggingFaceHub.DTO.ChatCompletion;
using HuggingFaceHub.Service;
using HuggingFaceHub.Utilities;

namespace HuggingFaceHub;

public class Class1 {
    public static void Main() {
        var huggingFaceClientService =
            new HuggingFaceClientService(apiToken: "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", 
                apiUrl : "https://router.huggingface.co/together/v1/chat/completions");

        var response = huggingFaceClientService.RequestChatCompletionAsync(
            new ChatCompletionRequestDto() {
                Model = "Qwen/Qwen2.5-Coder-32B-Instruct",
                Messages = [
                    new MessageDto() {
                        Role = ChatRoles.User,
                        Content = "HELLO"
                    }
                ]
            }
        );

        Console.WriteLine(response.Result?.Choices[0].Message);
    }
}