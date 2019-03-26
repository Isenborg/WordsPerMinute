using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronWebScraper;
using Newtonsoft.Json;

namespace WordsPerMinute
{
    class SweScraper : WebScraper
    {
        string url = "https://larare.at/svenska/moment/lingvistik/vanligaste_orden_i_svenska_spraket.html";
        public override void Init()
        {
            this.LoggingLevel = LogLevel.All;
            this.Request(url, Parse);
        }

        public override void Parse(Response response)
        {
            foreach(var Word_link in response.Css("ol ol li"))
            {
                string Content = Word_link.TextContentClean;
                var Data = new ScrapedData();
                Data["language"] = "Swedish";
                Data["Word"] = Content;
                Data["Length"] = Content.Length;
                string json = JsonConvert.SerializeObject(Data, Formatting.Indented);
                File.AppendAllText("Scrape/WordData.json", json);
            }
        }

    }
}
