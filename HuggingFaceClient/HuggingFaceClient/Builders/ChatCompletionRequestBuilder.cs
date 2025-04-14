using HuggingFaceClient.DTO.ChatCompletion;
using HuggingFaceClient.DTO.ChatCompletion.Response;
using HuggingFaceClient.Service;
using HuggingFaceClient.Utilities;

namespace HuggingFaceClient.Builders;

public class ChatCompletionRequestBuilder
{
    private readonly ChatCompletionRequestDto _request = new();

    private readonly HuggingFaceServiceOrchestrator _huggingFaceServiceOrchestrator;

    public ChatCompletionRequestBuilder(HuggingFaceServiceOrchestrator huggingFaceServiceOrchestrator)
    {
        _huggingFaceServiceOrchestrator = huggingFaceServiceOrchestrator;
    }

    public ChatCompletionRequestBuilder WithModel(string model)
    {
        _request.Model = model;
        return this;
    }

    public ChatCompletionRequestBuilder WithTemperature(double temperature)
    {
        _request.Temperature = temperature;
        return this;
    }

    public ChatCompletionRequestBuilder WithTopP(double topP)
    {
        _request.TopP = topP;
        return this;
    }

    public ChatCompletionRequestBuilder WithMaxNewTokens(int maxNewTokens)
    {
        _request.MaxNewTokens = maxNewTokens;
        return this;
    }

    public ChatCompletionRequestBuilder WithRepetitionPenalty(double penalty)
    {
        _request.RepetitionPenalty = penalty;
        return this;
    }

  
    public ChatCompletionRequestBuilder AddUserMessage(string content)
    {
        _request.Messages.Add(new MessageDto { Role = ChatRoles.User, Content = content });
        return this;
    }

    public ChatCompletionRequestBuilder AddAssistantMessage(string content)
    {
        _request.Messages.Add(new MessageDto { Role = ChatRoles.Assistant, Content = content });
        return this;
    }
    public ChatCompletionRequestBuilder AddSystemMessage(string content)
    {
        _request.Messages.Add(new MessageDto { Role = ChatRoles.System, Content = content });
        return this;
    }

    public async Task<ChatCompletionResponseDto?> SendAsync()
    {
        return await _huggingFaceServiceOrchestrator.ChatCompletionService.CreateChatAsync(_request);
    }

    public async Task<List<ChatCompletionStreamResponseDto>> SendStreamAsync() {
        return await _huggingFaceServiceOrchestrator.ChatCompletionService.CreateChatStreamAsync(_request);

    }

}