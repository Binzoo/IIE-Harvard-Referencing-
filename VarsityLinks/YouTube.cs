using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Net.Http;
namespace VarsityLinks
{
    internal class YouTube
    {
        private string ApiKey = "AIzaSyDwBlu5-FtoWzCC9ycT3shLwAPoa0x8xU8";
        private string BaseUrl = "https://www.googleapis.com/youtube/v3/videos";

        private async Task<string> GetVideoInfo(string videoId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                     var httpResponse = await httpClient.GetAsync($"{BaseUrl}?part=snippet&id={videoId}&key={ApiKey}");
                   
                    if (httpResponse.IsSuccessStatusCode)
                    {
                       var response = await httpResponse.Content.ReadAsStringAsync();
                       var jsonResponse = JObject.Parse(response);
                       
                        var channelName = jsonResponse["items"][0]["snippet"]["channelTitle"].ToString();
                        var title = jsonResponse["items"][0]["snippet"]["title"].ToString();
                        var dateCretaedYear = jsonResponse["items"][0]["snippet"]["publishedAt"].ToString().Substring(5, 4);
                        string dateTime = DateTime.Now.ToString().Substring(0, 9);

                       return ($"{title}.{dateCretaedYear}.YouTube video, added by {channelName}. [Online]. Available at: https://www.youtube.com/watch?v={videoId} [{dateTime}]");
                    }
                    else
                    {
                        return ($"Sorry, Video not found. Please check the link and give the correct link.");
                    }
                }
            }
            catch (Exception ex)
            {
                return ($"An error occurred: {ex.Message}");
            }
        }

        public async Task<string> getReference(string videoURL)
        {
           string link = videoURL.Substring(32);

           return await GetVideoInfo(link);
        }

    }
}
