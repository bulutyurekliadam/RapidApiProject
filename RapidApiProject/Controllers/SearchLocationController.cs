using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;

namespace RapidApiProject.Controllers
{
    public class SearchLocationController : Controller
    {
        public async Task<IActionResult> Index(string city)
        {
            if (!string.IsNullOrEmpty(city))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={city}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "3e258269b9msh4183e61387c8778p100991jsn26f74fe200fb" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<SearchLocationViewModel>>(body);
                    return View(values.ToList());
                }

            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Istanbul&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "3e258269b9msh4183e61387c8778p100991jsn26f74fe200fb" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<SearchLocationViewModel>>(body);
                    return View(values.ToList());
                }

            }

        }
    }
}
