using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerNews.Data;
using HackerNews.Model;

namespace HackerNews.Service
{
    public class ArticleService : IArticleServices
    {
        private readonly IData _hackerNewsData;
        private const int MAX_COUNT = 100;
        private const int MAX_TEXT = 256;




        public ArticleService(IData hackerNewsData)
        {
            _hackerNewsData = hackerNewsData;
        }

      //  public async Task<IList<Article>> GetTopArticles(int count = MAX_COUNT)
        //{
        //    if (count <= 0) return new List<Article>();

        //    var userRanks = new Dictionary<string, int>();

        //    var stories = _hackerNewsData.GetTopStories(count);
        //    var userNames = stories.GroupBy(x => x.By).Select(x => x.Key);

        //    foreach (var userName in userNames)
        //    {
        //        var user = await _hackerNewsData.GetUserProfile(userName);
        //        userRanks.Add(userName, user.Karma);
        //    }

        //    var articles = stories.Select(x => new Article
        //    {
        //        Author = x.By.Take(MAX_TEXT).ToString(),
        //        Comments = x.Kids != null ? x.Kids.Count() : 0,
        //        Points = x.Score ?? 0,
        //        Uri = x.Url,
        //        Title = x.Title.Take(MAX_TEXT).ToString(),
        //        Rank = userRanks.ContainsKey(x.By) ? userRanks[x.By] : 0
        //    }).ToList();

        //    return articles;
        //}

        public async Task<IList<Article>> GetTopArticles(int count = MAX_COUNT)
        {
            if (count <= 0) return new List<Article>();
            var userRanks = new Dictionary<string, int>();



            var stories = _hackerNewsData.GetTopStories(count);
            var userNames = stories.GroupBy(x => x.By).Select(x => x.Key);

            foreach (var userName in userNames)
            {
                var user = await _hackerNewsData.GetUserProfile(userName);
                userRanks.Add(userName, user.Karma);
            }
            var articles = stories.Select(x => new Article
            {
                Author = x.By.Take(MAX_TEXT).ToString(),
                Comments = x.Kids != null ? x.Kids.Count() : 0,
                Points = x.Score ?? 0,
                Uri = x.Url,
                Title = x.Title.Take(MAX_TEXT).ToString(),
                Rank = userRanks.ContainsKey(x.By) ? userRanks[x.By] : 0
            }).ToList();





            return articles;
        }
    }
}
