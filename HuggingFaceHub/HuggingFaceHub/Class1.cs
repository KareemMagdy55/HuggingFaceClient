using HuggingFaceHub.DTO.ChatCompletion;
using HuggingFaceHub.DTO.FeatureExtraction.Request;
using HuggingFaceHub.Service;
using HuggingFaceHub.Utilities;

namespace HuggingFaceHub;

public class Class1 {
    public static void Main() {
        var huggingFaceClientService =
            new HuggingFaceClientService(apiToken: "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", 
                apiUrl : "https://router.huggingface.co/hf-inference/pipeline/feature-extraction/intfloat/multilingual-e5-large-instruct");

        var response = huggingFaceClientService.RequestFeatureExtractionAsync(
            new FeatureExtractionRequestDto() {
              Inputs = "Hello , how are you"
            }
        );
        
        Console.WriteLine(response.Result?.Features[0]);
    }
}