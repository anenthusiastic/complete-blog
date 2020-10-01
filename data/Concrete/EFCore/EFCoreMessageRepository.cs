using data.Abstract;
using entity;

namespace data.Concrete.EFCore
{
    public class EFCoreMessageRepository : EFCoreGenericRepository<Message, Context>, IMessageRepository
    {
        
    }
}