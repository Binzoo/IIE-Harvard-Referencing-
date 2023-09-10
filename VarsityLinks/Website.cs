using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarsityLinks
{
    internal class Website
    {

       

        private async Task<string> getWebsiteInfo(string url)
        {
            string year = getYear();
            string name = getName(url);
            string monthAndDate = yearCreated();

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Let's assume each article title is inside an <h2> tag with a class "article-title"
            var articleTitles = htmlDocument.DocumentNode.SelectNodes("//h1");
           
            string articleName = string.Empty;

            if (articleTitles != null)
            {
               articleName = articleTitles[0].InnerText.Trim();
                return $"{name}. {year}. {articleName}, {monthAndDate} {year}. [Online]. Available at: {url} [Accessed {DateTime.Now}]";
            }
            else
            {
                return $"{name}. {year}. DID NOT FOUND THE TITLE PLEASE GO THE LINK AND MANUALLY ADD THE HEADING, {monthAndDate} {year}. [Online]. Available at: {url} [Accessed {DateTime.Now}]";
            }


            
        }


        private string yearCreated()
        {
            string[] months =
                            {
                                "January", "February", "March", "April", "May", "June",
                                "July", "August", "September", "October", "November", "December"
                            };

          

            Random random = new Random();

            // Assuming all months can have 28 days
            int day = random.Next(1, 29);
            string month = months[random.Next(12)];
          

            return $"{day} {month}";
        } 



        private string getYear()
        {
            Random random = new Random();
            int[] years =
                          {
                        2020, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016,
                        2017, 2018, 2019, 2020, 2021, 2022, 2023
                    };
            int year = years[random.Next(years.Length)];
            return year.ToString();
        }



        private string getName(string url) 
        {
            Uri uri = new Uri(url);
            string host = uri.Host; // This gives you "www.easterseals.com"

            string[] splitHost = host.Split('.');
            if (splitHost.Length > 1)
            {
                string subdomain = splitHost[1]; // This gives you "easterseals"
                return (subdomain);
            }
            return "Not found";
        }


        public async Task<string> getReference(string url)
        {
            return await getWebsiteInfo(url);
        }
    }
}
