using System.Collections.Generic;
using entity;

namespace data.Abstract
{
    public interface IPostCategoryRepository:IRepository<PostCategory>
    {
         List<int> GetPosts (int categoryId);
          List<int> GetCategories (int postId);
    }
}