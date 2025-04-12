namespace HuggingFaceHub.DTO.ChatCompletion;

public class ChatCompletionRequestDto
{
    public string Model { get; set; } = "default-model"; 
    public List<MessageDto> Messages { get; set; } = new();   
    public double? Temperature { get; set; }
    public double? TopP { get; set; } 
    public int? MaxNewTokens { get; set; } 
    public int? RepetitionPenalty { get; set; } 
    public bool? Stream { get; set; }
}