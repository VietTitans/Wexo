using RestSharp;

namespace Webapplication.Models;

public class MediaApiService : IMediaApiService
{
    private readonly RestClient _client;
    private readonly string _bearerToken;

    public MediaApiService(IConfiguration configuration)
    {
        _bearerToken = configuration["ConnectionString"];
        var options = new RestClientOptions("https://api.themoviedb.org/3/");
        _client = new RestClient(options);
    }

    public async Task<RestResponse> GetResponseByUriAsync(string uri)
    {
        var request = new RestRequest(uri, Method.Get);
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {_bearerToken}");

        var response = await _client.ExecuteAsync(request);
        return response;
    }
}
