using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.TextToImage.Response;

public class DataChunkDto {
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("timings")]
    public TimingsDto Timings { get; set; }

}

public class TimingsDto {
    [JsonPropertyName("inference")]
    public double Inference { get; set; }
}