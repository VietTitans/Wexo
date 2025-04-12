using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Webapplication.Models;

namespace Webapplication.Controllers
{
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            //Index method is called when the program launches. 

            //****************** GET GenreId in movie category ******************
            //URI: https://api.themoviedb.org/3/genre/movie/list

            var genres = new List<Genre>();
            var genreListResponse = await GetResponseByUri("genre/movie/list");

            if (genreListResponse.IsSuccessful && genreListResponse.Content != null)
            {
                var result = JsonConvert.DeserializeObject<GenreResponse>(genreListResponse.Content);
                genres = result.Genres;
            }

            //****************** Get genre stats ******************
            genres = await GetMoviesByGenre(genres);

            return View(genres);
        }

        [HttpPost]
        //Uri: /Movie/Genre/{genreId}
        public async Task<IActionResult> MoviesByGenreId(int genreId)
        {
            List<Media> movieList = new();

            var allMoviesResponse = await GetResponseByUri($"/discover/movie?with_genres={genreId}");

            TempData["PreviousGenre"] = genreId; 

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
            //ViewBag.ReturnUrl = returnUrl ?? Url.Content($"/discover/movie?with_genres={TempData["PreviousGenre"]}");


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
                    .Where(c => !string.IsNullOrWhiteSpace(c.Name)) //Filter to only include CastMember.Name. If condition is true, then include.
                    .Take(5) //Display only five froom the list
                    .ToList();//Convert to a type of List. Where and Distinct returns type of IEnumerable.

                //Add directors to list
                movieDetails.Directors = creditResult.Crew
                    .Where(c => c.Job == "Director") //Filter to only include crew with a job called director. 
                    .Distinct() //Remove duplicates
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
        private static async Task<List<Genre>> GetMoviesByGenre(List<Genre> genres)
        {
            //A list of target genres are defined by genre id.
            //GenreId corresponds to the provided requirements.
            List<int> allowedGenreIds = new() { 28, 35, 53, 10752, 10749, 18, 80, 99, 27 };

            var resultGenres = new List<Genre>();

            foreach (var genreId in allowedGenreIds)
            {
                //URI: https://api.themoviedb.org/3/discover/movie?with_genres=GENRE_ID
                var moviesByGenreResponse = await GetResponseByUri($"/discover/movie?with_genres={genreId}");

                if (moviesByGenreResponse.IsSuccessful && moviesByGenreResponse.Content != null)
                {
                    var result = JsonConvert.DeserializeObject<MovieResponse>(moviesByGenreResponse.Content);

                    //Return the first element that matches the condition regardless of
                    //multiple matches. Otherwise return null if no matches was found. 
                    var genreInfo = genres.FirstOrDefault(g => g.Id == genreId);

                    if (genreInfo != null)
                    {
                        //Create genre object with the all the statistics
                        resultGenres.Add(new Genre
                        {
                            Id = genreId,
                            Name = genreInfo.Name,
                            TotalMovieCount = result.TotalResults,
                            Items = result.Results
                        });
                    }
                }
            }

            return resultGenres;
        }
    }
}
