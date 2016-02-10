using System;
using System.Xml.Linq;
using System.Drawing;

namespace AnimeHelper.Data
{
    public class Anime
    {
        
        public int ID { get; set; }
        public string Tittle { get; set; }
        public string EngTittle { get; set; }
        public int Episodes { get; set; }
        public double Score { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }

    }
}