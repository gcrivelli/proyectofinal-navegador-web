using NavegadorWeb.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NavegadorWeb.Controller
{
    public class TourController
    {
        private static string APIurl = "https://proyecto-final-navegador-web.herokuapp.com/api/";

        /// <summary>
        /// Get a specific tour 
        /// </summary>
        /// <param name="id"> id of the tour to be search </param>
        /// <returns></returns>
        public async Task<Tour> GetTourAsync(string id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(APIurl + "tour/" + id).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Tour>(responseBody);
            }
        }

        /// <summary>
        /// Get all the tours of a specific user
        /// </summary>
        /// <param name="id"> id of the user to be search </param>
        /// <returns></returns>
        public async Task<User> GetAllToursAsync(string id)
        {
            using (var client = new HttpClient())
            {
                //change url
                var response = await client.GetAsync(APIurl + "user/"+ id +"/tour").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(responseBody);
            }
        }

        /// <summary>
        /// Post a specific tutorial with their steps and elements
        /// </summary>
        /// <param name="tour"> tour to be saved </param>
        /// <returns></returns>
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

