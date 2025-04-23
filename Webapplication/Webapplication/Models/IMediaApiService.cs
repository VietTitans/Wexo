using RestSharp;

namespace Webapplication.Models;

public interface IMediaApiService
{
    Task<RestResponse> GetResponseByUriAsync(string uri);
}
