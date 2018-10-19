using HackerNewsDotNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerNews.Data
{
    public interface IData
    {
        IQueryable<HackerNewsItem> GetTopStories(int count);
        Task<HackerNewsUserProfile> GetUserProfile(string userId);
    }
}
