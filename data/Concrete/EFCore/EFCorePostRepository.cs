using System.Collections.Generic;
using System.Linq;
using data.Abstract;
using entity;

namespace data.Concrete.EFCore
{
    public class EFCorePostRepository : EFCoreGenericRepository<Post, Context>, IPostRepository
    {
        public List<Post> GetPopularPostOfAllTimes()
        {
            return GetAll().OrderByDescending(p => p.viewCount).ToList().GetRange(0,5);
        }

        public List<Post> GetPopularPostOfThisMonth()
        {
            List<Post> monthpost = new List<Post>();
            var posts = GetAll().OrderByDescending(p => p.viewCount).ToList();
            int i = 0;
            while(monthpost.Count<5 & i<posts.Count)
            {
                if((posts[i].date.Year == System.DateTime.Now.Year) & (posts[i].date.Month == System.DateTime.Now.Month)){
                    monthpost.Add(posts[i]);
                }
                i++;
            }
            return monthpost;
        }
    }
}