using System.Collections.Generic;
using entity;
namespace data.Abstract
{
    public interface IPostRepository:IRepository<Post>
    {
       List<Post> GetPopularPostOfAllTimes();
       List<Post> GetPopularPostOfThisMonth();

    }
}