using movies;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarvelMoviesClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await SendNewMarvelMovie();
            await PrintMarvelMovies();
        }

        private static async Task SendNewMarvelMovie()
        {
            using (var httpClient = new HttpClient())
            {
                var baseUrl = "https://localhost:44376/";
                var client = new swaggerClient(baseUrl, httpClient);
                var newMovie = new Movie()
                {
                    Id = 4,
                    Title = "Captain Marvel",
                    PublicationYear = 2019,
                    Rating = 6.9f,
                    Stars = new [] { "Brie Larson", "Samuel L. Jackson", "Ben Mendelsohn", "Jude Law" }
                };

                await client.MarvelMoviesAsync(newMovie).ConfigureAwait(false);
            }
        }

        private static async Task PrintMarvelMovies()
        {
            using (var httpClient = new HttpClient())
            {
                var baseUrl = "https://localhost:44376/";
                var client = new swaggerClient(baseUrl, httpClient);
                var movies = await client.MarvelMoviesAllAsync().ConfigureAwait(false);
                foreach (var movie in movies)
                {
                    Console.WriteLine(movie.Title);
                }
            }
        }
    }
}
