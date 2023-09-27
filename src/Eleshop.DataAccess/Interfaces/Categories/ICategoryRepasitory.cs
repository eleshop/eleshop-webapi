using Eleshop.DataAccess.Common;
using Eleshop.Domain.Entites.Categories;

namespace Eleshop.DataAccess.Interfaces.Categories;

public interface ICategoryRepasitory : IRepository<Category,Category>,
    IGetAll<Category>
{

}
