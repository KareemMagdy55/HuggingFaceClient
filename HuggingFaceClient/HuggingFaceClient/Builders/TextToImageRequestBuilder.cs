using System.Net.Http.Json;
using HuggingFaceClient.DTO.TextToImage;
using HuggingFaceClient.DTO.TextToImage.Response;
using HuggingFaceClient.Service;

namespace HuggingFaceClient.Builders;

public class TextToImageRequestBuilder {
    private TextToImageRequestDto _request;
    private readonly HuggingFaceServiceOrchestrator _huggingFaceServiceOrchestrator;

    
    public TextToImageRequestBuilder(HuggingFaceServiceOrchestrator huggingFaceServiceOrchestrator) {
        _huggingFaceServiceOrchestrator = huggingFaceServiceOrchestrator;
        _request = new TextToImageRequestDto();
        _request.ParametersDto = new TextToImageParametersDto(); 
    }

    public TextToImageRequestBuilder WithInputs(string inputs) {
        _request.Inputs = inputs;
        return this;
    }

    public TextToImageRequestBuilder WithPrompt(string prompt) {
        _request.Prompt = prompt;
        return this;
    }

    public TextToImageRequestBuilder WithModel(string model) {
        _request.Model = model;
        return this;
    }

    public TextToImageRequestBuilder WithGuidanceScale(float? guidanceScale) {
        _request.ParametersDto.GuidanceScale = guidanceScale;
        return this;
    }

    public TextToImageRequestBuilder WithNegativePrompt(string negativePrompt) {
        _request.ParametersDto.NegativePrompt = negativePrompt;
        return this;
    }

    public TextToImageRequestBuilder WithNumInferenceSteps(int? numInferenceSteps) {
        _request.ParametersDto.NumInferenceSteps = numInferenceSteps;
        return this;
    }

    public TextToImageRequestBuilder WithWidth(int? width) {
        _request.ParametersDto.Width = width;
        return this;
    }

    public TextToImageRequestBuilder WithHeight(int? height) {
        _request.ParametersDto.Height = height;
        return this;
    }

    public TextToImageRequestBuilder WithScheduler(string scheduler) {
        _request.ParametersDto.Scheduler = scheduler;
        return this;
    }

    public TextToImageRequestBuilder WithSeed(int? seed) {
        _request.ParametersDto.Seed = seed;
        return this;
    }

    public TextToImageRequestDto Build() {
        return _request;
    }

    public async Task<TextToImageResponseDto?> SendAsync() {
        return await _huggingFaceServiceOrchestrator.TextToImageService.ConvertTextToImageAsync(_request);
    }
}