using Eleshop.DataAccess.Common;
using Eleshop.DataAccess.Repository;
using Eleshop.DataAccess.ViewModel;
using Eleshop.Domain.Entites.Users;

namespace Eleshop.DataAccess.Interfaces.Heads;

public interface IHeadRepository : IRepository<User, UserViewModel>,
    IGetAll<UserViewModel>, ISearchable<UserViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);
}
