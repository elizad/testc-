using HackerNews.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNews.Service
{
    public interface IArticleServices
    {
        Task<IList<Article>> GetTopArticles(int count);
    }
}