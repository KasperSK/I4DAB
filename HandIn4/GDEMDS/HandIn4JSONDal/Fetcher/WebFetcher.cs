using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace HandIn4JSONDal.Fetcher
{
    public class WebFetcher
    {
        WebRequest FecthRequest;
        private string basePath = "http://userportal.iha.dk/~jrt/i4dab/E14/HandIn4/dataGDL/data/";
        private List<string> jsonFiles;
        private int pointer = 5;

        public WebFetcher()
        {
            FecthRequest = WebRequest.Create(basePath);
            jsonFiles = new List<string>();
            GetFilePath();
        }

        private void GetFilePath()
        {
            var response = FecthRequest.GetResponse();

            var responseStream = response.GetResponseStream();
            if(responseStream == null)
                return;

            var sr = new StreamReader(responseStream);

            var html = sr.ReadToEnd();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                jsonFiles.Add(link.InnerText);
            }
        }

        public string GetNextJson()
        {
            Console.WriteLine(basePath + jsonFiles[pointer]);
            FecthRequest = WebRequest.Create(basePath + jsonFiles[pointer]);

            var response = FecthRequest.GetResponse();

            var responseStream = response.GetResponseStream();
            if (responseStream == null)
                return "NO DATA";
            var sr = new StreamReader(responseStream);

            if (pointer < jsonFiles.Count - 1)
                ++pointer;
            else
            {
                pointer = 5;
            }

            return sr.ReadToEnd();
        }
    }
}
