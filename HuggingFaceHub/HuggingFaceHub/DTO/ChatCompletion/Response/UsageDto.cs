namespace HuggingFaceHub.DTO.ChatCompletion.Response;

public class UsageDto {
    public int PromptTokens { get; set; }
    public int CompletionTokens { get; set; }  
    public int TotalTokens { get; set; } 
}