
using Eleshop.Domain.Entites.Users;

namespace Eleshop.Services.Interfaces.Auth;

public interface ITokenService
{
    public Task<string> GenerateToken(User user);

    //public Task<string> GenerateToken(Admin admin);

    //public Task<string> GenerateToken(Head head);
}
