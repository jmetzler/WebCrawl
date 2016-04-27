using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawl
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];
            var list = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }                
            }

            foreach (var item in list)
            {
                var fileName = Path.GetDirectoryName(path) + @"..\CityOutput\" + item + ".html";
                Task<string> stuff = GetAsync("http://www.ronjohnsonforsenate.com/" + item, fileName);
            }

            
           // Task<string> stuff = GetAsync("http://www.codingCubism.com");
            while (true)
            {
            }

        }
        public static async Task<string> GetAsync(string uri, string fileName)
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(uri);
            File.WriteAllText(fileName, content);
            return content;
        }
    }
}
