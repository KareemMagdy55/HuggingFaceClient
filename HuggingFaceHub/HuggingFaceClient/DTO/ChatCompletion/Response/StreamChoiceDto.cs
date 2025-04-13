using System.Text.Json.Serialization;

namespace HuggingFaceClient.DTO.ChatCompletion.Response;

public class StreamChoiceDto {
        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("logprobs")]
        public object Logprobs { get; set; }

        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; set; }

        [JsonPropertyName("seed")]
        public object Seed { get; set; }

        [JsonPropertyName("delta")]
        public DeltaDto Delta { get; set; }

}