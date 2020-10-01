using System.Collections.Generic;
using entity;

namespace data.Abstract
{
    public interface ICommentRepository : IRepository<Comment>
    {
         List<Comment> GetPostComments(int PostId);
    }
}