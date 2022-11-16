using Newtonsoft.Json.Linq;

var apiKey = "c43d574b3e4d08bbd37fe5f80ffeb393";
var httpClient = new HttpClient();

Console.WriteLine("Enter City: ");
var cityName = Console.ReadLine();

var directGeoCodingUrl = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={apiKey}";
var response = httpClient.GetStringAsync(directGeoCodingUrl).Result;

var formattedResponse = JObject.Parse(response).GetValue("main")?.ToString();
var temp = JObject.Parse(formattedResponse).GetValue("temp").ToString();
var feelsLike = JObject.Parse(formattedResponse).GetValue("feels_like").ToString();

Console.WriteLine(cityName);
if (formattedResponse != null)
{
    Console.WriteLine($"Temperature: {temp}f");
    Console.WriteLine(($"Feels Like: {feelsLike}f"));
}