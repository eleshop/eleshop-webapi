using Eleshop.DataAccess.Common;
using Eleshop.DataAccess.ViewModel;
using Eleshop.Domain.Entites.Users;

namespace Eleshop.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, UserViewModel>,
    IGetAll<UserViewModel>, ISearchable<UserViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);
}
