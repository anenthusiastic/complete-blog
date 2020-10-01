using entity;

namespace data.Abstract
{
    public interface ILoginInfoRepository:IRepository<LoginInfo>
    {
         LoginInfo GetByUsername(string username);
         bool Validate(string un,string pass);
    }
}