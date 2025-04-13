using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using HuggingFaceHub.Utilities;

namespace HuggingFaceHub.Service;

public static class HttpRequestService {
    private static readonly HttpClient _httpClient = new HttpClient();

    public static async Task<TResponse?> _RequestAsync<TRequest, TResponse>(TRequest requestDto)
        where TRequest : class
        where TResponse : class {
        try {
            var requestJson = JsonSerializer.Serialize(requestDto);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, HuggingFaceGlobalConfig.ApiBaseUrl) {
                Content = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json")
            };

            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", HuggingFaceGlobalConfig.ApiToken);

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

    public static async IAsyncEnumerable<TResponse?> _RequestStreamAsync<TRequest, TResponse>(
        TRequest requestDto
    )
        where TResponse : class
        where TRequest : class {
        var response = new HttpResponseMessage();
        try {
            var requestJson = JsonSerializer.Serialize(requestDto);

            var requestMessage =
                new HttpRequestMessage(HttpMethod.Post, HuggingFaceGlobalConfig.ApiBaseUrl) {
                    Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
                };

            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", HuggingFaceGlobalConfig.ApiToken);

            response = await _httpClient.SendAsync(
                requestMessage,
                HttpCompletionOption.ResponseHeadersRead
            );

            if (!response.IsSuccessStatusCode) {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Error ({response.StatusCode}): {error}");
                yield break;
            }
        }
        catch (Exception e) {
            Console.WriteLine($"Exception: {e.Message}");
        }

        var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        using var reader = new StreamReader(stream);

        while (!reader.EndOfStream) {
            var line = await reader.ReadLineAsync();
            if (line.StartsWith("data:"))
                line = line[6..].Trim(); // To get rid of "token"

            if (line == "[DONE]")
                yield break;

            TResponse? parsed = null;
            if (!string.IsNullOrEmpty(line))
                parsed = JsonSerializer.Deserialize<TResponse>(line,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


            yield return parsed;
        }
    }
}