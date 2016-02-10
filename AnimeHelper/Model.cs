using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AnimeHelper.Data;

namespace AnimeHelper
{
    public class Model
    { 
        private readonly HttpClient _client;
        private WebWorking webWorking = Factory.GetWebWorking();
        //Initial HttpClient   
        public Model()
        {
            _client=new HttpClient();

        }

     
        public async Task<IEnumerable<Anime>> LoadAnimeFromRequest(string request)
        {
            return await GetDataFromRequset(request);

        }

        private async Task<IEnumerable<Anime>> GetDataFromRequset(string request)
        {
           
            var data = await webWorking.GetAnime(request);

            XDocument document = XDocument.Parse(data.Content.ReadAsStringAsync().Result);
       
            return document.Descendants("entry").Select(elem => new Anime
            {
                ID = int.Parse(elem.Element("id").Value),
                Tittle = elem.Element("title").Value,
                EngTittle = elem.Element("english").Value,
                Episodes = int.Parse(elem.Element("episodes").Value),
                Score = double.Parse(elem.Element("score").Value, CultureInfo.InvariantCulture),
                Type = elem.Element("type").Value,
                Status = elem.Element("status").Value,
             
            }).ToList();
        }

        
       
  
    }
}