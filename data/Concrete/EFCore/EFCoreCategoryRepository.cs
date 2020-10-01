using data.Abstract;
using entity;

namespace data.Concrete.EFCore
{
    public class EFCoreCategoryRepository : EFCoreGenericRepository<Category, Context>, ICategoryRepository
    {
        
    }
}