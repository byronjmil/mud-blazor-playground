using System.Text.Json;

namespace ThreeDiamonds.Service;
public interface IHttpService
{
    Task<T?> GetApiDataAsync<T>(string apiUrl) where T : class;
    Task<T?> PostApiDataAsync<T>(string apiUrl, StringContent jsonContent) where T : class;
    Task<T?> PatchApiDataAsync<T>(string apiUrl, StringContent jsonContent) where T : class;
    Task<HttpResponseMessage> HttpPostResponseMessage<T>(string apiUrl, StringContent jsonContent) where T : class;
    Task<HttpResponseMessage> HttpPutResponseMessage<T>(string apiUrl, StringContent jsonContent) where T : class;
    Task<HttpResponseMessage> HttpDeleteResponseMessage<T>(string apiUrl, StringContent jsonContent) where T : class;
    Task<HttpResponseMessage> HttpGetResponseMessage<T>(string apiUrl) where T : class;
}

public class HttpService : IHttpService
{
    private readonly HttpClient http;

    public HttpService(HttpClient http)
    {
        this.http = http;
    }

    public async Task<HttpResponseMessage> HttpGetResponseMessage<T>(string apiUrl) where T : class
    {
        HttpResponseMessage response = await http.GetAsync(apiUrl);
        return response;
    }

    public async Task<HttpResponseMessage> HttpPostResponseMessage<T>(string apiUrl, StringContent jsonContent) where T : class
    {
        HttpResponseMessage response = await http.PostAsync(apiUrl, jsonContent);
        return response;
    }

    public async Task<HttpResponseMessage> HttpPutResponseMessage<T>(string apiUrl, StringContent jsonContent) where T : class
    {
        HttpResponseMessage response = await http.PutAsync(apiUrl, jsonContent);
        return response;
    }

    public async Task<HttpResponseMessage> HttpDeleteResponseMessage<T>(string apiUrl, StringContent jsonContent) where T : class
    {
        HttpRequestMessage? request = new()
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri(apiUrl),
            Content = jsonContent
        };

        HttpResponseMessage response = await http.SendAsync(request);
        return response;
    }

    public async Task<T?> PostApiDataAsync<T>(string apiUrl, StringContent? jsonContent) where T : class
    {
        try
        {
            HttpResponseMessage response = await http.PostAsync(apiUrl, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                string? responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseContent);
            }
            else
            {
                return JsonSerializer.Deserialize<T>("");
            }
        }
        catch (JsonException)
        {
            throw new ServiceException("Unable to parse JSON from response");
        }
        catch (Exception ex)
        {
            throw new ServiceException($"Service Error: {ex.Message}", ex);
        }
    }

    public async Task<T?> GetApiDataAsync<T>(string apiUrl) where T : class
    {
        try
        {
            string? response = await http.GetStringAsync(apiUrl);
            return JsonSerializer.Deserialize<T>(response);
        }
        catch (JsonException)
        {
            throw new ServiceException("Unable to parse JSON from response");
        }
        catch (Exception ex)
        {
            throw new ServiceException($"Service Error: {ex.Message}", ex);
        }
    }

    public async Task<T?> PatchApiDataAsync<T>(string apiUrl, StringContent? jsonContent) where T : class
    {
        try
        {
            HttpResponseMessage response = await http.PatchAsync(apiUrl, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                string? responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseContent);
            }
            else
            {
                return JsonSerializer.Deserialize<T>("");
            }
        }
        catch (JsonException)
        {
            throw new ServiceException("Unable to parse JSON from response");
        }
        catch (Exception ex)
        {
            throw new ServiceException($"Service Error: {ex.Message}", ex);
        }
    }
}

public class ServiceException : Exception
{
    public ServiceException(string message) : base(message) { }
    public ServiceException(string message, Exception innerException) : base(message, innerException) { }
}
