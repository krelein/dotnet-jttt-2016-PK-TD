using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;

namespace DemotMail
{
    class PicturesFromHtml
    {
        private readonly string _url;


        public PicturesFromHtml(string url)
        {
            this._url = url;
        }
        public List<string> AdFileIf(string phrase)
        {
            List<string> files = new List<string>();
            LogFile.AddLog("Rozpoczęto przeszukiwanie strony w poszukiwaniu plików do załączenia");
           
            var wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var html = System.Net.WebUtility.HtmlDecode(wc.DownloadString(_url));

            var doc = new HtmlDocument();
            var pageHtml = html;
            doc.LoadHtml(pageHtml);
            var nodes = doc.DocumentNode.Descendants("img");

            foreach (var node in nodes)
            {
                if(node.GetAttributeValue("alt","").Contains(phrase))
                {        
                    files.Add(node.GetAttributeValue("src", ""));
                    LogFile.AddLog("Dodano plik do listy o adresie " + node.GetAttributeValue("src", ""));
                }
            }

            return files;
        }

    }
}
