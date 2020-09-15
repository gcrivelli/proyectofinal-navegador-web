using NavegadorWeb.Models;
using NavegadorWeb.UI;
using Newtonsoft.Json;
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
    }
}
