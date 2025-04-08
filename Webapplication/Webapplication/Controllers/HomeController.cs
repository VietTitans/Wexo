using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Webapplication.Models;
using RestSharp;

namespace Webapplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> Index()
    {
        var genres = new List<Genre>();
        var medias = new List<Media>();


        //****************** GET GenreId in movie category ******************
        //URI: https://api.themoviedb.org/3/genre/movie/list
        var genreListResponse = await GetResponseByUri("genre/movie/list");

        if (genreListResponse.IsSuccessful && genreListResponse.Content != null)
        {
            var result = JsonConvert.DeserializeObject<GenreResponse>(genreListResponse.Content);
            genres = result.Genres;
        }

        //****************** Get total movie count in a genre inorder display total movie count ******************
        await GetTotalMovieCountByGenre(genres);

        //****************** Get all movies within a genre******************
        //URI: https://api.themoviedb.org/3/discover/movie
        var response = await GetResponseByUri("/discover/movie");

        if (response.IsSuccessful && response.Content != null)
        {
            var movieResponse = JsonConvert.DeserializeObject<MovieResponse>(response.Content);
            medias = movieResponse.Results;
        }

        //****************** Adding movies and series into their genres ******************
        foreach (var media in medias)
        {
            foreach (var genre in genres)
            {
                //Looping through the media.genreIds list and check if contains genre.id
                bool idMatch = media.GenreIds.Contains(genre.Id);

                //Check for null and check if the name media.Genre and genre.Name are equal to each other.
                //StringComparision makes the string case insensitive.
                bool nameMatch = !string.IsNullOrWhiteSpace(media.Genre) &&
                                 string.Equals(media.Genre, genre.Name, StringComparison.OrdinalIgnoreCase);

                if (idMatch || nameMatch)
                {
                    genre.Items.Add(media);
                }
            }

        }
        return View(genres);
    }

    private static async Task GetTotalMovieCountByGenre(List<Genre> genres)
    {
        //A list of target genres are defined by genre id
        List<int> allowedGenreIds = new() { 28, 35, 53, 10752, 10749, 18, 80, 99, 27 };

        foreach (var genreId in allowedGenreIds)
        {
            //URI: https://api.themoviedb.org/3/discover/movie?with_genres=GENRE_ID
            var moviesByGenreResponse = await GetResponseByUri($"/discover/movie?with_genres={genreId}");

            if (moviesByGenreResponse.IsSuccessful && moviesByGenreResponse.Content != null)
            {
                var result = JsonConvert.DeserializeObject<MovieResponse>(moviesByGenreResponse.Content);

                var genreInfo = genres.FirstOrDefault(g => g.Id == genreId);

                if (genreInfo != null)
                {
                    genres.Add(new Genre
                    {
                        Id = genreId,
                        Name = genreInfo.Name,
                        TotalMovieCount = result.TotalResults,
                        Items = result.Results
                    });
                }
            }
        }

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

