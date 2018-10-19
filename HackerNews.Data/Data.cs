using HackerNewsDotNet;
using HackerNewsDotNet.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Data
{
    public class Data : IData
    {
        private readonly HackerNewsApi _api;


        public Data()
        {
            _api = new HackerNewsApi();
        }


        public IQueryable<HackerNewsItem> GetTopStories(int count)
        {
            return _api.TopStories(count).AsQueryable();
        }

        public async Task<HackerNewsUserProfile> GetUserProfile(string userId)
        {
            return await _api.UserProfile(userId);
        }
    }
}
