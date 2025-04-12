using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using HuggingFaceHub.DTO.ChatCompletion;
using HuggingFaceHub.DTO.ChatCompletion.Response;

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

    public async Task<ChatCompletionResponseDto?> RequestChatCompletionAsync(ChatCompletionRequestDto requestDto) {
        try {
            var requestJson = JsonSerializer.Serialize(requestDto);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, _apiUrl) {
                Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
            };

            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken);

            var response = await _httpClient.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"HuggingFace API Error ({response.StatusCode}): {error}");
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var parsed = JsonSerializer.Deserialize<ChatCompletionResponseDto>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return parsed;
        }

        catch (Exception e) {
            return null;
        }
    }
}