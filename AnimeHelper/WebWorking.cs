using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnimeHelper
{

    class WebWorking
    {
        private readonly HttpClient _client;

        public WebWorking()
        {
            _client = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetAnime(string request)
        {
            return await _client.GetAsync($"http://myanimelist.net/api/anime/search.xml?q={request}");
        }

        //User Verify method
        public async Task<HttpStatusCode> UserVerify(string user, string password)
        {
            _client.DefaultRequestHeaders.Add("Authorization",
                "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(user + ":" + password)));
            var checkTask = await _client.GetAsync("http://myanimelist.net/api/account/verify_credentials.xml");

            return checkTask.StatusCode;
        }
    }
}
