namespace HuggingFaceHub.DTO.ChatCompletion.Response;

public class ChatCompletionResponseDto {
    public List<ChatChoiceDto> Choices { get; set; } = new(); 
    public UsageDto? Usage { get; set; }
}