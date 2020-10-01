using System.Linq;
using data.Abstract;
using entity;

namespace data.Concrete.EFCore
{
    public class EFCoreLoginInfoRepository : EFCoreGenericRepository<LoginInfo, Context>, ILoginInfoRepository
    {
        public LoginInfo GetByUsername(string username)
        {
            return GetAll().FirstOrDefault(x => (x.id == username));
        }

        public bool Validate(string un, string pass)
        {
            LoginInfo info = GetByUsername(un);
           
            if((info!=null) && info.password.Equals(pass)){
                return true;
            }
            
            return false;
        }
    }
}