using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Webapplication.Models;

namespace Webapplication.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View("/");
        }

        [HttpPost]
        //Uri: /Movie/Genre/{genreId}
        public async Task<IActionResult> MoviesByGenreId(int genreId)
        {
            List<Media> movieList = new();

            var allMoviesResponse = await GetResponseByUri($"/discover/movie?with_genres={genreId}");

            if (allMoviesResponse.IsSuccessful && allMoviesResponse.Content != null)
            {
                var resultResponse = JsonConvert.DeserializeObject<MovieResponse>(allMoviesResponse.Content);

                foreach (var movie in resultResponse.Results)
                {
                    movieList.Add(movie);
                }
            }
            return View(movieList);
        }

        [HttpGet]
        //Movie/Details/{id}
        public async Task<IActionResult> Details(int id)
        {

            MediaDetailsResponse movieDetails = null;
            var detailsResponse = await GetResponseByUri($"/movie/{id}");

            if (detailsResponse.IsSuccessful && detailsResponse.Content != null)
            {
                var result = JsonConvert.DeserializeObject<MediaDetailsResponse>(detailsResponse.Content);

                movieDetails = result;
            }
            else
            {
                return NotFound();
            }
            return View(movieDetails);
        }

        private static async Task<RestResponse> GetResponseByUri(string uri)
        {
            var options = new RestClientOptions("https://api.themoviedb.org/3/");
            var client = new RestClient(options);
            var request = new RestRequest(uri, Method.Get);

            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {Environment.GetEnvironmentVariable("ConnectionString")}");

            var response = await client.GetAsync(request);

            return response;
        }
    }
}
