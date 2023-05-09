using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Joke
{
    public interface IWebApi
    {
        public int LenJoke();

        public int LenJoke(string joke);

        public string GetJoke();
    }
    public class WebAPI : IWebApi
    {
        public HttpClient client = new HttpClient();

        public int LenJoke(string joke)
        {
            return joke.Length;
        }

        public int LenJoke()
        {
            string joke = GetJoke();
            return joke.Length;
        }

        public string GetJoke()
        {
            string url = "https://api.chucknorris.io/jokes/random";
            string joke = "";

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var answer = response.Content.ReadAsStringAsync().Result;
                var result = Newtonsoft.Json.Linq.JObject.Parse(answer);
                joke = (string)result["value"];
            }
            else
            {
                joke = "No jokes are available";
            }

            return joke;
        }

        public static async Task Main(string[] args)
        {
            var WebApi = new WebAPI();
            string joke = WebApi.GetJoke();
            int lenght = WebApi.LenJoke(joke);
            Console.WriteLine(joke);
            Console.WriteLine($"The lenght of the joke is: {lenght}");

        }
    }
}

