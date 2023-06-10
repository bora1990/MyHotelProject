using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Consume.Models;

namespace RapidApi.Consume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMovieViewModel> apiMovieViewModels = new List<ApiMovieViewModel>();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
            {
        { "X-RapidAPI-Key", "fcc917b06amshef0279bc7db36f7p13a42djsnea390bd6c306" },//Apiye istekte bulunurken kullanacağımız key değeridir.Keyler, API isteklerinin kimlik doğrulaması ve izin verilen erişimi kontrol etmek için kullanılır.
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },//API sağlayıcısın linkidir.
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                //Api deki verilerin hepsini almak zorunda değiliz istediğimiz verileri view modelde belirterek istediklerimizi alabilirz.
                apiMovieViewModels = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
                return View(apiMovieViewModels);

            }
        }
    }
}

