using Eleshop.DataAccess.Common;
using Eleshop.Domain.Entites.Laptops;

namespace Eleshop.DataAccess.Interfaces.Laptops;

public interface ILaptopRepository : IRepository<Laptop, Laptop>,
    IGetAll<Laptop>
{

}
