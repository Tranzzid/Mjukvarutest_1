using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

class Program
{
    static HttpClient client = new HttpClient();
    static Random rand = new Random();

    static async Task<int> LenJokeAsync()
    {
        string joke = await GetJokeAsync();
        return joke.Length;
    }

    static async Task<string> GetJokeAsync()
    {
        string url = "https://api.chucknorris.io/jokes/random";
        string joke = "";

        HttpResponseMessage response = await client.GetAsync(url);

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

    static async Task Main(string[] args)
    {
        string joke = await GetJokeAsync();
        Console.WriteLine(joke);
    }
}
