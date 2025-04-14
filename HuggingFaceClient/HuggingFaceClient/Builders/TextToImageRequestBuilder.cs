using HuggingFaceClient.DTO.TextToImage;
using HuggingFaceClient.DTO.TextToImage.Response;
using HuggingFaceClient.Service;

namespace HuggingFaceClient.Builders;

/// <summary>
/// A fluent builder for constructing and sending text-to-image generation requests to Hugging Face.
///
/// This class wraps the creation of a <see cref="TextToImageRequestDto"/> and allows you to customize image
/// generation parameters such as guidance scale, image dimensions, negative prompts, scheduler, and more.
/// Once the configuration is complete, the request can be sent using the <see cref="SendAsync"/> method.
/// </summary>
public class TextToImageRequestBuilder
{
    private readonly TextToImageRequestDto _request = new()
    {
        ParametersDto = new TextToImageParametersDto()
    };

    private readonly HuggingFaceServiceOrchestrator _huggingFaceServiceOrchestrator;

    /// <summary>
    /// Initializes a new instance of the <see cref="TextToImageRequestBuilder"/> class.
    /// </summary>
    /// <param name="huggingFaceServiceOrchestrator">The orchestrator responsible for invoking the Hugging Face image generation service.</param>
    public TextToImageRequestBuilder(HuggingFaceServiceOrchestrator huggingFaceServiceOrchestrator)
    {
        _huggingFaceServiceOrchestrator = huggingFaceServiceOrchestrator;
    }

    /// <summary>
    /// Sets the textual input or prompt used to generate the image.
    /// Corresponds to <see cref="TextToImageRequestDto.Inputs"/>.
    /// </summary>
    /// <param name="inputs">The description or text prompt guiding the image generation.</param>
    /// <returns>The current builder instance.</returns>
    public TextToImageRequestBuilder WithInputs(string inputs)
    {
        _request.Inputs = inputs;
        return this;
    }

    /// <summary>
    /// Sets the guidance scale to influence how closely the generated image follows the prompt.
    /// Corresponds to <see cref="TextToImageParametersDto.GuidanceScale"/>.
    /// </summary>
    /// <param name="guidanceScale">A float value, typically between 1.0 and 20.0.</param>
    /// <returns>The current builder instance.</returns>
    public TextToImageRequestBuilder WithGuidanceScale(float guidanceScale)
    {
        _request.ParametersDto.GuidanceScale = guidanceScale;
        return this;
    }

    /// <summary>
    /// Sets a negative prompt to instruct the model what to avoid during image generation.
    /// Corresponds to <see cref="TextToImageParametersDto.NegativePrompt"/>.
    /// </summary>
    /// <param name="negativePrompt">Text describing unwanted content in the image.</param>
    /// <returns>The current builder instance.</returns>
    public TextToImageRequestBuilder WithNegativePrompt(string negativePrompt)
    {
        _request.ParametersDto.NegativePrompt = negativePrompt;
        return this;
    }

    /// <summary>
    /// Sets the number of inference steps for the generation process.
    /// Higher values can improve image quality at the cost of performance.
    /// Corresponds to <see cref="TextToImageParametersDto.NumInferenceSteps"/>.
    /// </summary>
    /// <param name="steps">Number of steps (e.g., 25, 50).</param>
    /// <returns>The current builder instance.</returns>
    public TextToImageRequestBuilder WithInferenceSteps(int steps)
    {
        _request.ParametersDto.NumInferenceSteps = steps;
        return this;
    }

    /// <summary>
    /// Sets the width of the resulting image in pixels.
    /// Corresponds to <see cref="TextToImageParametersDto.Width"/>.
    /// </summary>
    /// <param name="width">Image width in pixels (e.g., 512).</param>
    /// <returns>The current builder instance.</returns>
    public TextToImageRequestBuilder WithWidth(int width)
    {
        _request.ParametersDto.Width = width;
        return this;
    }

    /// <summary>
    /// Sets the height of the resulting image in pixels.
    /// Corresponds to <see cref="TextToImageParametersDto.Height"/>.
    /// </summary>
    /// <param name="height">Image height in pixels (e.g., 512).</param>
    /// <returns>The current builder instance.</returns>
    public TextToImageRequestBuilder WithHeight(int height)
    {
        _request.ParametersDto.Height = height;
        return this;
    }

    /// <summary>
    /// Specifies the scheduler algorithm used for generating the image.
    /// This controls the diffusion process and can impact style and speed.
    /// Corresponds to <see cref="TextToImageParametersDto.Scheduler"/>.
    /// </summary>
    /// <param name="scheduler">The scheduler type (e.g., "ddim", "pndm", "euler").</param>
    /// <returns>The current builder instance.</returns>
    public TextToImageRequestBuilder WithScheduler(string scheduler)
    {
        _request.ParametersDto.Scheduler = scheduler;
        return this;
    }

    /// <summary>
    /// Sets a random seed for deterministic image generation.
    /// Using the same seed and prompt will produce identical images.
    /// Corresponds to <see cref="TextToImageParametersDto.Seed"/>.
    /// </summary>
    /// <param name="seed">A numeric seed value.</param>
    /// <returns>The current builder instance.</returns>
    public TextToImageRequestBuilder WithSeed(int seed)
    {
        _request.ParametersDto.Seed = seed;
        return this;
    }

    /// <summary>
    /// Sends the constructed text-to-image request to Hugging Face and returns the response.
    /// Internally invokes <see cref="TextToImageService.ConvertTextToImageAsync"/>.
    /// </summary>
    /// <returns>A task containing the image generation response.</returns>
    public async Task<TextToImageResponseDto?> SendAsync()
    {
        return await _huggingFaceServiceOrchestrator.TextToImageService.ConvertTextToImageAsync(_request);
    }
}
