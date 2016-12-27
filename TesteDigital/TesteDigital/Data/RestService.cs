using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TesteDigital
{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<Personagem> Items { get; private set; }

        public RestService()
        {
            var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task<List<Personagem>> RefreshDataAsync()
        {
            Items = new List<Personagem>();

            // RestUrl = http://developer.xamarin.com:8081/api/todoitems{0}
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Personagem>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Items;
        }

    }
}
