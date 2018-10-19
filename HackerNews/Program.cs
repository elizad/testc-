using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HackerNews.Model;
using HackerNews.Service;
using Newtonsoft.Json;

namespace HackerNews
{
    class Program
    {
    
        public async Task  Main(string[] args)
        {

            if (args == null || args.Length != 2 || args[0] != "--posts")
            {
                Console.WriteLine("USE hackernews --posts n");
                return;
            }


            if (!int.TryParse(args[1], out var count))
            {
                Console.WriteLine("n must be a number");
                return;
            }

            if (count > 100 || count <= 0)
            {
                Console.WriteLine("n must be a number > 0 and <= 100 ");
                return;
            }

            var data = new HackerNews.Data.Data();
            var  service = new ArticleService(data);
            var articles =  service.GetTopArticles(count);


            await Task.Delay(2000);


            Console.WriteLine(FormatArticlesForDisplay(articles));
            Console.ReadLine();
        }

       

        private string FormatArticlesForDisplay(Task<IList<Article>> articles)
        {
              return JsonConvert.SerializeObject(articles, Formatting.Indented);
        }

    }
}
