using data.Abstract;
using entity;

namespace data.Concrete.EFCore
{
    public class EFCoreHeaderRepository : EFCoreGenericRepository<Header, Context>, IHeaderRepository
    {
        
    }
}