using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace Project.Service.Helpers
{
    public  class HttpClientHelper
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HttpClientHelper(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<TResponse> PostContentAsync<TRequest, TResponse>(TRequest requestData, string requestUrl, string? authToken = default)
        {
            var httpClient = httpClientFactory.CreateClient(HttpClientNames.TodoService);
            if (!string.IsNullOrEmpty(authToken))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            var json = JsonSerializer.Serialize(requestData);
            var data = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await httpClient.PostAsync(requestUrl, data);

            response.EnsureSuccessStatusCode();
            using var result = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<TResponse>(result);
        }

        public async Task<TResponse> UpdateAsync<TRequest, TResponse>(TRequest requestData, string requestUrl, string? authToken = default)
        {
            var httpClient = httpClientFactory.CreateClient(HttpClientNames.TodoService);
            if (!string.IsNullOrEmpty(authToken))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            var json = JsonSerializer.Serialize(requestData);
            var data = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await httpClient.PutAsync(requestUrl, data);

            response.EnsureSuccessStatusCode();
            using var result = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<TResponse>(result);
        }

        public async Task<TResult> GetResultAsync<TResult>(string requestUrl, string? authToken = default)
        {
            var httpClient = httpClientFactory.CreateClient(HttpClientNames.TodoService);
            if (!string.IsNullOrEmpty(authToken))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            var response = await httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            using var result = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<TResult>(result);
        }

        public static class HttpClientNames
        {
            public const string TodoService = "TodoServiceClient";
        }
    }
}
