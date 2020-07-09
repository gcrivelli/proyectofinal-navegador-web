using NavegadorWeb.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NavegadorWeb.Controller
{
    public class TourController
    {
        private static string APIurl = "https://proyecto-final-navegador-web.herokuapp.com/api/tour";
        public async Task<Tour> GetAsync(string id)
        {
            using (var client = new HttpClient())
            {
                //change url
                var response = await client.GetAsync("https://proyecto-final-navegador-web.herokuapp.com/api/tour/1");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Tour>(responseBody);
            }
        }

        public async Task<string> PostAsync(Tour tour)
        {
            string JSONresult = JsonConvert.SerializeObject(tour);

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(APIurl,
                     new StringContent(JSONresult, Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();
                var a = await response.Content.ReadAsStringAsync();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}

