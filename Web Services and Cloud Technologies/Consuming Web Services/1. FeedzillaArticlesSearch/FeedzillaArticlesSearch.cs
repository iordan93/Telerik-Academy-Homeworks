namespace _1.FeedzillaArticlesSearch
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using Newtonsoft.Json;

    public class FeedzillaArticlesSearch
    {
        public static void Main()
        {
            HttpClient client = new HttpClient();
            Console.Write("Enter the query string to search for: ");
            string queryString = Console.ReadLine();
            Console.Write("Enter the number of results to show (default: 10, max: 100): ");
            string resultsString = Console.ReadLine();
            int results = 10;
            if (!string.IsNullOrWhiteSpace(resultsString))
            {
                results = int.Parse(resultsString);
            }

            ArticleCollection articles = GetArticles(client, queryString, results);
            if (articles.Articles.Any())
            {
                foreach (var article in articles.Articles)
                {
                    Console.WriteLine("{0}{1}{2}{1}", article.Title, Environment.NewLine, article.Url);
                }
            }
            else
            {
                Console.WriteLine("There are no articles to show.");
            }
        }

        private static ArticleCollection GetArticles(HttpClient client, string queryString, int results)
        {
            string url = string.Format("http://api.feedzilla.com/v1/articles/search.json?q={0}&count={1}", queryString, results);
            HttpResponseMessage response = client.GetAsync(url).Result;
            string articlesContent = response.Content.ReadAsStringAsync().Result;
            ArticleCollection articles = JsonConvert.DeserializeObject<ArticleCollection>(articlesContent);

            return articles;
        }
    }
}