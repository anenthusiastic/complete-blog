using System.Collections.Generic;
using System.Linq;
using data.Abstract;
using entity;

namespace data.Concrete.EFCore
{
    public class EFCoreCommentRepository : EFCoreGenericRepository<Comment, Context>, ICommentRepository
    {
        public List<Comment> GetPostComments(int PostId)
        {
            return GetAll().Where(c => (c.PostId == PostId)).OrderByDescending(c=> c.date).ToList();
        }
    }
}