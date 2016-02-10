using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeHelper
{
   static class Factory
    {
        static WebWorking web;


        public static WebWorking GetWebWorking()
        {
            return web ?? (web = new WebWorking());
        }
    }
}
