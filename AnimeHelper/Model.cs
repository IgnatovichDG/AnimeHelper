using System;
using System.Net.Http;
using System.Text;

namespace AnimeHelper
{
    internal class Model
    {
        private readonly HttpClient _client = new HttpClient();

        public bool UserVerify(string user, string password)
        {
            _client.DefaultRequestHeaders.Add("Authorization",
                "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(user + ":" + password)));
            var check = _client.GetAsync("http://myanimelist.net/api/account/verify_credentials.xml").Result;
            return check.IsSuccessStatusCode; //TODO: Написать проверку на Exceptions
        }
    }
}