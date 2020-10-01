using System.Collections.Generic;
using System.Linq;
using data.Abstract;
using entity;

namespace data.Concrete.EFCore
{
    public class EFCorePostCategoryRepository : EFCoreGenericRepository<PostCategory, Context>, IPostCategoryRepository
    {
        public List<int> GetCategories(int pId)
        {
            return  GetAll().Where(c => (c.postId.Equals(pId))).Select(c =>(c.categoryId)).ToList();
        }

        public List<int> GetPosts(int catId)
        {
            return  GetAll().Where(c => (c.categoryId.Equals(catId))).Select(c =>(c.postId)).ToList();
        }
    }
}