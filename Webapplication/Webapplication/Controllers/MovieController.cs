using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Webapplication.Models;

namespace Webapplication.Controllers
{
    public class MovieController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View("~/");
        //}

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
        //Uri: /Movie/Details/{id}
        public async Task<IActionResult> Details(int id, string returnUrl)
        {
            MediaDetailsResponse movieDetails = null;

            //Get movie details
            var detailsResponse = await GetResponseByUri($"/movie/{id}");

            //Used to redirect user back to this url, when pressing "go back" button.
            //ViewBag.ReturnUrl = returnUrl ?? Url.Content($"/discover/movie?with_genres={genreId}");


            if (detailsResponse.IsSuccessful && detailsResponse.Content != null)
            {
                var result = JsonConvert.DeserializeObject<MediaDetailsResponse>(detailsResponse.Content);

                movieDetails = result;
            }
            else
            {
                return NotFound();
            }

            //Get credit details
            var creditResponse = await GetResponseByUri($"/movie/{id}/credits");
            if (creditResponse.IsSuccessStatusCode && creditResponse.Content != null)
            {
                var creditResult = JsonConvert.DeserializeObject<CreditResponse>(creditResponse.Content);

                //Add actors to list
                movieDetails.Actors = creditResult.Cast
                    .Where(c => !string.IsNullOrWhiteSpace(c.Name))
                    .Take(5)
                    .ToList();

                //Add directors to list
                movieDetails.Directors = creditResult.Crew
                    .Where(c => c.Job == "Director")
                    .Distinct()
                    .ToList();
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
