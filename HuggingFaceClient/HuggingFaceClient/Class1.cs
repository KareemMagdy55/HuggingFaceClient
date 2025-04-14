using HuggingFaceClient.Builders;
using HuggingFaceClient.DTO.TextToImage;
using HuggingFaceClient.Service;

namespace HuggingFaceClient;

public class Class1 {
    public static void Main() {
        // HuggingFaceClient huggingFaceClientService = new HuggingFaceClientService("fdlask", "lkfdas;f");
        var hfClient = new HfClient("bl", "bla");

        var lo = hfClient.Chat.WithModel("klfds").AddUserMessage("Hello").SendAsync();
    }
}