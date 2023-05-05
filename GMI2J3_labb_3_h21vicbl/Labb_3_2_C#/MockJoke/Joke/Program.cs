using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

public class WebAPI
{
    public HttpClient client = new HttpClient();

    public async Task<int> LenJokeAsync()
    {
        string joke = await GetJokeAsync();
        return joke.Length;
    }

	public async Task<string> GetJokeAsync()
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

	public static async Task Main(string[] args)
    {
        var WebApi = new WebAPI();
        string joke = await WebApi.GetJokeAsync();
        int lenght = await WebApi.LenJokeAsync();
        Console.WriteLine(joke);
		Console.WriteLine($"The lenght of the joke is: {lenght}");

    }
}
