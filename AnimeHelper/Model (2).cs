using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AnimeHelper.Data;

namespace AnimeHelper
{
    public class Model
    {   //TODO: List for saving anime
        private readonly HttpClient _client;

        private List<Anime> AnimeList = new List<Anime>(); 
        public Model()
        {
            _client=new HttpClient();
        }

        public void LoadAnimeFromRequest()
        {
            AnimeList.Clear();

        }
        public async Task<HttpStatusCode> UserVerify(string user, string password)
        {
            _client.DefaultRequestHeaders.Add("Authorization",
                "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(user + ":" + password)));
            var checkTask =  _client.GetAsync("http://myanimelist.net/api/account/verify_credentials.xml");
            var check = await checkTask;
            return check.StatusCode;
        }
    }
}