﻿using NavegadorWeb.Models;
using NavegadorWeb.UI;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NavegadorWeb.Controller
{
    public class NotificationController
    {
        private static string APIurl = Constants.ApiUrl;

        public async Task<Notification> getNotification ()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Constants.token);
                var response = await client.GetAsync(APIurl + "notificar").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Notification>(responseBody);
            }
        }
        public async Task<bool> postNotification(Notification notification)
        {
            string JSONresult = JsonConvert.SerializeObject(notification);

            using (var client = new HttpClient())
            {
                var urlPost = APIurl + "notificar";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Constants.token);
                var response = await client.PostAsync(urlPost,
                     new StringContent(JSONresult, Encoding.UTF8, "application/json")).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
        }
    }
}
