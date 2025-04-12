namespace HuggingFaceHub.DTO.ChatCompletion.Response;

public class ChatChoiceDto {
    public int Index { get; set; }   
    public MessageDto Message { get; set; } = new(); 
    public string FinishReason { get; set; } = "";
}