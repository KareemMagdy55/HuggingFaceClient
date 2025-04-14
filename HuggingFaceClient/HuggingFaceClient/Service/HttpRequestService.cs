using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using HuggingFaceClient.Utilities;

namespace HuggingFaceClient.Service {
    ///
    /// Provides methods to send HTTP requests to the HuggingFace API.
    ///
    public static class HttpRequestService {
        private static readonly HttpClient _httpClient = new HttpClient();
        
        /// <summary>
        /// Sends an asynchronous HTTP POST request with a JSON body and deserializes the response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request DTO.</typeparam>
        /// <typeparam name="TResponse">The type of the expected response DTO.</typeparam>
        /// <param name="requestDto">The request data transfer object containing the request payload.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the deserialized response,
        /// or null if an error occurred.
        /// </returns>
        public static async Task<TResponse?> _PostRequestAsync<TRequest, TResponse>(TRequest requestDto)
            where TRequest : class
            where TResponse : class {
            try {
                var requestJson = JsonSerializer.Serialize(requestDto);
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, HuggingFaceGlobalConfig.ApiBaseUrl) {
                    Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
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

        
         /// <summary>
        /// Sends an asynchronous HTTP Get request with a JSON body and deserializes the response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request DTO.</typeparam>
        /// <typeparam name="TResponse">The type of the expected response DTO.</typeparam>
        /// <param name="requestDto">The request data transfer object containing the request payload.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the deserialized response,
        /// or null if an error occurred.
        /// </returns>
        public static async Task<TResponse?> _GetRequestAsync<TRequest, TResponse>(TRequest requestDto)
            where TRequest : class
            where TResponse : class {
            try {
                var requestJson = JsonSerializer.Serialize(requestDto);
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, HuggingFaceGlobalConfig.ApiBaseUrl) {
                    Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
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

        /// <summary>
        /// Sends an asynchronous HTTP POST request with a JSON body and returns a stream of deserialized responses.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request DTO.</typeparam>
        /// <typeparam name="TResponse">The type of the expected response DTO.</typeparam>
        /// <param name="requestDto">The request data transfer object containing the request payload.</param>
        /// <returns>
        /// An asynchronous enumerable stream of deserialized responses.
        /// </returns>
        public static async IAsyncEnumerable<TResponse?> _RequestStreamAsync<TRequest, TResponse>(TRequest requestDto)
            where TRequest : class
            where TResponse : class {
            HttpResponseMessage response = new HttpResponseMessage();
            try {
                var requestJson = JsonSerializer.Serialize(requestDto);
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, HuggingFaceGlobalConfig.ApiBaseUrl) {
                    Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
                };
                if (HuggingFaceGlobalConfig.ApiToken != "") ;
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", HuggingFaceGlobalConfig.ApiToken);

                response = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);

                if (!response.IsSuccessStatusCode) {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Error ({response.StatusCode})");
                    yield break;
                }
            }
            catch (Exception e) {
                Console.WriteLine($"Exception: {e.Message}");
                yield break;
            }

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            using var reader = new StreamReader(stream);

            while (!reader.EndOfStream) {
                var line = await reader.ReadLineAsync();

                if (line.StartsWith("data:"))
                    line = line[6..].Trim();

                if (line == "[DONE]")
                    yield break;

                TResponse? parsed = null;
                if (!string.IsNullOrEmpty(line)) {
                    parsed = JsonSerializer.Deserialize<TResponse>(line,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                yield return parsed;
            }
        }
    }
}