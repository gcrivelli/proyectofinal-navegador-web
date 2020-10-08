using NavegadorWeb.Models;
using NavegadorWeb.UI;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NavegadorWeb.Controller
{
    public class UserController
    {
        private static string APIurl = Constants.ApiUrl;

        public async Task<Token> LoginAsync(User user)
        {
            string JSONresult = JsonConvert.SerializeObject(user);

            using (var client = new HttpClient())
            {
                var urlPost = APIurl + "login";
                var response = await client.PostAsync(urlPost,
                     new StringContent(JSONresult, Encoding.UTF8, "application/json")).ConfigureAwait(false);

                try
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Token>(responseBody);
                }
                catch (HttpRequestException)
                {
                    return JsonConvert.DeserializeObject<Token>("");
                }                
            }
        }

        public async Task<Token> RegisterAsync(User user)
        {
            string JSONresult = JsonConvert.SerializeObject(user);

            using (var client = new HttpClient())
            {
                var urlPost = APIurl + "register";
                var response = await client.PostAsync(urlPost,
                    new StringContent(JSONresult, Encoding.UTF8, "application/json")).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Token>(responseBody);
                
            }
        }

        public async Task<Token> RegisterOldPeopleAsync(User user)
        {
            string JSONresult = JsonConvert.SerializeObject(user);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Constants.token);
                var urlPost = APIurl + "registerOldPeople";
                var response = await client.PostAsync(urlPost,
                    new StringContent(JSONresult, Encoding.UTF8, "application/json")).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Token>(responseBody);

            }
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var values = new Dictionary<string, string>
            {
                  { "email", email }
            };

            var content = new FormUrlEncodedContent(values);
            using (var client = new HttpClient())
            {
                try
                {
                    var urlPost = APIurl + "forgotpassword";
                    var response = await client.PostAsync(urlPost, content).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return response.EnsureSuccessStatusCode().IsSuccessStatusCode;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<bool> AsignTourAdult(string idTour, string idAdult)
        {
            using (var client = new HttpClient())
            {
                var urlPost = APIurl + "user/" + idAdult + "/tour/" + idTour;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Constants.token);
                var response = await client.PostAsync(urlPost,
                     new StringContent("", Encoding.UTF8, "application/json")).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
        }
        
        public async Task<bool> DeleteAsignTourAdult(string idTour, string idAdult)
        {
            using (var client = new HttpClient())
            {
                var urlDelete = APIurl + "user/" + idAdult + "/tour/" + idTour;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Constants.token);
                var response = await client.DeleteAsync(urlDelete);

                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
        }

    }
}
