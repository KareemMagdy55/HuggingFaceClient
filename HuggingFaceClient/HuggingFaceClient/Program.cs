using HuggingFaceClient.Builders;

namespace HuggingFaceClient;

public class Program {
    public static void Main() {
        var hf = new HfClient("MAIN", "https://router.huggingface.co/together/v1/chat/completions");
        var response = hf.Chat.WithModel("Qwen/Qwen2.5-Coder-32B-Instruct").SendAsync();
        // Console.WriteLine(response.Result?);
    }
}