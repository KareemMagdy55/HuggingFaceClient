using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.TextToImage;

public class TextToImageParametersDto {
    [JsonPropertyName("guidance_scale")]
    public float? GuidanceScale { get; set; }

    [JsonPropertyName("negative_prompt")]
    public string NegativePrompt { get; set; }

    [JsonPropertyName("num_inference_steps")]
    public int? NumInferenceSteps { get; set; }

    [JsonPropertyName("width")]
    public int? Width { get; set; }

    [JsonPropertyName("height")]
    public int? Height { get; set; }

    [JsonPropertyName("scheduler")]
    public string Scheduler { get; set; }

    [JsonPropertyName("seed")]
    public int? Seed { get; set; }}