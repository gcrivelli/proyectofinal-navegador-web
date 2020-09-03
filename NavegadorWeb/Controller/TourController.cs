using NavegadorWeb.Models;
using NavegadorWeb.UI;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NavegadorWeb.Controller
{
    public class TourController
    {
        private static string APIurl = Constants.ApiUrl;

        /// <summary>
        /// Get a specific tour 
        /// </summary>
        /// <param name="id"> id of the tour to be search </param>
        /// <returns></returns>
        public async Task<Tour> GetTourAsync(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Constants.token);
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
        public async Task<List<Tour>> GetAllToursAsync(string id)
        {
            using (var client = new HttpClient())
            {
                //change url
                client.DefaultRequestHeaders.Add("Authorization", "Bearer "+ Constants.token);
                var response = await client.GetAsync(APIurl + "user/"+ id +"/tour").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Tour>>(responseBody);
            }
        }

        /// <summary>
        /// Post a specific tutorial with their steps and elements
        /// </summary>
        /// <param name="tour"> tour to be saved </param>
        /// <returns></returns>
        public async Task<Tour> PostAsync(Tour tour)
        {
            string JSONresult = JsonConvert.SerializeObject(tour);

            using (var client = new HttpClient())
            {
                var urlPost = APIurl + "tour";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Constants.token);
                var response = await client.PostAsync(urlPost,
                     new StringContent(JSONresult, Encoding.UTF8, "application/json")).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Tour>(responseBody);
            }
        }

        public async Task<bool> PostAudio(string file_path, string tourId, string stepId)
        {
            var audioContent = new ByteArrayContent(System.IO.File.ReadAllBytes(file_path));
            audioContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/wav");

            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(audioContent, "audio", "hello1.wav");

            var url = APIurl + "tour/" + tourId +"/step/" + stepId +"/audio";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Constants.token);
            var response = await httpClient.PostAsync(url, form).ConfigureAwait(false);

            File.Delete(file_path);
            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> GetAudio(string tourId, string stepId)
        {
            using (var client = new HttpClient())
            {                
                var url = APIurl + "tour/" + tourId + "/step/" + stepId + "/audio";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Constants.token);
                var response = await client.GetAsync(url).ConfigureAwait(false);
                var filename = Constants.audioPath + "/Audio " + tourId + stepId+ ".wav";

                var responseBody = await response.Content.ReadAsByteArrayAsync();
                System.IO.File.WriteAllBytes(filename, responseBody);

                return response.IsSuccessStatusCode;
            }
        }
    }
}

