using HuggingFaceClient.DTO.TextToImage;
using HuggingFaceClient.Service;

namespace HuggingFaceClient;

public class Class1 {
    public static void Main() {
        var huggingFaceClientService =
            new HuggingFaceClientService(apiToken: "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", 
                apiBaseUrl : "https://router.huggingface.co/hf-inference/models/black-forest-labs/FLUX.1-dev");
        
        var message = huggingFaceClientService.TextToImageService.ConvertTextToImageAsync(
            new TextToImageRequestDto() {
               Model = "openfree/flux-chatgpt-ghibli-lora",
               Prompt = "Cat riding a bike"
            });
        Console.WriteLine(message.Result?.Data[0].Url);
        
    }
}