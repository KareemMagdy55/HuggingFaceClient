using HuggingFaceClient.DTO.ChatCompletion;
using HuggingFaceClient.DTO.ChatCompletion.Response;
using HuggingFaceClient.Service;
using HuggingFaceClient.Utilities;

namespace HuggingFaceClient.Builders;

/// <summary>
/// A fluent builder for constructing and sending chat completion requests to Hugging Face.
/// 
/// This builder simplifies the creation of <see cref="ChatCompletionRequestDto"/> instances by providing a
/// chainable interface and encapsulates logic for populating chat messages and controlling generation behavior.
/// </summary>
public class ChatCompletionRequestBuilder
{
    private readonly ChatCompletionRequestDto _request = new();

    private readonly HuggingFaceServiceOrchestrator _huggingFaceServiceOrchestrator;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatCompletionRequestBuilder"/> class.
    /// </summary>
    /// <param name="huggingFaceServiceOrchestrator">The orchestrator responsible for managing service calls, including chat completion requests.</param>
    public ChatCompletionRequestBuilder(HuggingFaceServiceOrchestrator huggingFaceServiceOrchestrator)
    {
        _huggingFaceServiceOrchestrator = huggingFaceServiceOrchestrator;
    }

    /// <summary>
    /// Specifies the model to use for chat completion.
    /// </summary>
    /// <param name="model">The model identifier (e.g., "mistral-7b", "meta-llama").</param>
    /// <returns>The current builder instance.</returns>
    public ChatCompletionRequestBuilder WithModel(string model)
    {
        _request.Model = model;
        return this;
    }

    /// <summary>
    /// Sets the temperature to control randomness in the output.
    /// Higher values like 1.0 make the output more random, while lower values like 0.2 make it more focused and deterministic.
    /// </summary>
    /// <param name="temperature">A value between 0.0 and 1.0.</param>
    /// <returns>The current builder instance.</returns>
    public ChatCompletionRequestBuilder WithTemperature(double temperature)
    {
        _request.Temperature = temperature;
        return this;
    }

    /// <summary>
    /// Sets the top-p value for nucleus sampling.
    /// The model considers the smallest possible set of words whose cumulative probability exceeds the top-p value.
    /// </summary>
    /// <param name="topP">A probability value between 0.0 and 1.0.</param>
    /// <returns>The current builder instance.</returns>
    public ChatCompletionRequestBuilder WithTopP(double topP)
    {
        _request.TopP = topP;
        return this;
    }

    /// <summary>
    /// Specifies the maximum number of new tokens the model is allowed to generate in the response.
    /// </summary>
    /// <param name="maxNewTokens">Maximum number of new tokens.</param>
    /// <returns>The current builder instance.</returns>
    public ChatCompletionRequestBuilder WithMaxNewTokens(int maxNewTokens)
    {
        _request.MaxNewTokens = maxNewTokens;
        return this;
    }

    /// <summary>
    /// Applies a repetition penalty to discourage repeated phrases or tokens.
    /// Values > 1.0 penalize repetition more heavily.
    /// </summary>
    /// <param name="penalty">The repetition penalty value.</param>
    /// <returns>The current builder instance.</returns>
    public ChatCompletionRequestBuilder WithRepetitionPenalty(double penalty)
    {
        _request.RepetitionPenalty = penalty;
        return this;
    }

    /// <summary>
    /// Adds a user message to the chat conversation history.
    /// </summary>
    /// <param name="content">The content of the user message.</param>
    /// <returns>The current builder instance.</returns>
    public ChatCompletionRequestBuilder AddUserMessage(string content)
    {
        _request.Messages.Add(new MessageDto
        {
            Role = ChatRoles.User,
            Content = content
        });
        return this;
    }

    /// <summary>
    /// Adds an assistant message to the chat conversation history.
    /// </summary>
    /// <param name="content">The content of the assistant's message.</param>
    /// <returns>The current builder instance.</returns>
    public ChatCompletionRequestBuilder AddAssistantMessage(string content)
    {
        _request.Messages.Add(new MessageDto
        {
            Role = ChatRoles.Assistant,
            Content = content
        });
        return this;
    }

    /// <summary>
    /// Adds a system message to the chat conversation history, typically used to set behavior or context.
    /// </summary>
    /// <param name="content">The content of the system message.</param>
    /// <returns>The current builder instance.</returns>
    public ChatCompletionRequestBuilder AddSystemMessage(string content)
    {
        _request.Messages.Add(new MessageDto
        {
            Role = ChatRoles.System,
            Content = content
        });
        return this;
    }

    /// <summary>
    /// Sends the chat request to Hugging Face and returns the full structured response.
    /// </summary>
    /// <returns>A task containing the chat completion result from the model.</returns>
    public async Task<ChatCompletionResponseDto?> SendAsync()
    {
        return await _huggingFaceServiceOrchestrator.ChatCompletionService.CreateChatAsync(_request);
    }

    /// <summary>
    /// Sends the chat request to Hugging Face using streaming mode,
    /// returning a list of response chunks progressively generated by the model.
    /// </summary>
    /// <returns>A task containing a list of streamed chat completion responses.</returns>
    public async Task<List<ChatCompletionStreamResponseDto>> SendStreamAsync()
    {
        return await _huggingFaceServiceOrchestrator.ChatCompletionService.CreateChatStreamAsync(_request);
    }
}
