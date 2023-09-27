using Eleshop.DataAccess.Common;
using Eleshop.Domain.Entites.Telephones;

namespace Eleshop.DataAccess.Interfaces.Telephones;

public interface ITelephoneRepository : IRepository<Telephone, Telephone>,
    IGetAll<Telephone>
{

}
