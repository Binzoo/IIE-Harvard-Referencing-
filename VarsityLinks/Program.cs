using System;
using System.Net.Http;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;


namespace VarsityLinks
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {

            // YouTube youTube = new YouTube();

            // Console.WriteLine(await youTube.getReference("https://www.youtube.com/watch?v=cuHoGm81VkA"));


            Website website = new Website();
            Console.WriteLine(await website.getReference("https://www.quora.com/How-does-YouTube-never-run-out-of-video-IDs")); 

            


        }


    }
}