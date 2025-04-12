using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using HuggingFaceHub.DTO.ChatCompletion;
using HuggingFaceHub.DTO.ChatCompletion.Response;
using HuggingFaceHub.DTO.FeatureExtraction.Request;
using HuggingFaceHub.DTO.FeatureExtraction.Response;

namespace HuggingFaceHub.Service;

public class HuggingFaceClientService {
    private readonly HttpClient _httpClient;
    private readonly string _apiToken;
    private readonly string _apiUrl;

    public HuggingFaceClientService(string apiToken, string apiUrl) {
        _httpClient = new HttpClient();
        _apiToken = apiToken;
        _apiUrl = apiUrl;
    }

    public async Task<ChatCompletionResponseDto?> RequestChatCompletionAsync(ChatCompletionRequestDto requestDto) =>
        await RequestAsync<ChatCompletionRequestDto, ChatCompletionResponseDto>(requestDto);

    public async Task<FeatureExtractionResponseDto> RequestFeatureExtractionAsync(
        FeatureExtractionRequestDto requestDto)
        =>
            new FeatureExtractionResponseDto {
                Features = await RequestAsync<FeatureExtractionRequestDto, object[]>(requestDto)
            };


    private async Task<TResponse?> RequestAsync<TRequest, TResponse>(TRequest requestDto)
        where TRequest : class
        where TResponse : class {
        try {
            var requestJson = JsonSerializer.Serialize(requestDto);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, _apiUrl) {
                Content = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json")
            };

            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken);

            var response = await _httpClient.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode) {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Error ({response.StatusCode}): {error}");
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var parsed = JsonSerializer.Deserialize<TResponse>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return parsed;
        }
        catch (Exception e) {
            Console.WriteLine($"Exception: {e.Message}");
            return null;
        }
    }
}