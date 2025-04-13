using HuggingFaceClient.DTO.ChatCompletion;
using HuggingFaceClient.DTO.TextToImage;
using HuggingFaceClient.Service;
using HuggingFaceClient.Utilities;

namespace HuggingFaceClient;

public class Class1 {
    public static void Main() {
        var huggingFaceClientService =
            new HuggingFaceClientService(apiToken: "HF_TOKEN", 
                apiBaseUrl : "https://router.huggingface.co/together/v1/images/generations");
        
        var message = huggingFaceClientService.TextToImageService.ConvertTextToImageAsync(
            new TextToImageRequestDto() {
               Model = "black-forest-labs/FLUX.1-dev",
               Prompt = "Cat riding a bike"
            });
        Console.WriteLine(message.Result?.Data[0].Url);
        
    }
}