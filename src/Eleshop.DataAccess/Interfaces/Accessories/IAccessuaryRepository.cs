using Eleshop.DataAccess.Common;
using Eleshop.Domain.Entites.Accessories;

namespace Eleshop.DataAccess.Interfaces.Accessories;

public interface IAccessuaryRepository : IRepository<Accessory, Accessory>,
    IGetAll<Accessory>
{

}
