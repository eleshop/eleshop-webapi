using Eleshop.Application.Utilities;
using Eleshop.DataAccess.ViewModel;
using Eleshop.Domain.Entites;
using Eleshop.Persistance.Dtos.Users;

namespace Eleshop.Services.Interfaces.Admins;

public interface IAdminService
{
    public Task<UserViewModel> GetByIdAsync(long id);

    public Task<bool> UpdateAsync(long adminId, string phone, UserUpdateDto dto);

    //public Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params);

    //public Task<Human> GetByIdAsync();

    //public Task<bool> CreateAsync(AdminCreateDto dto);

    //public Task<bool> UpdateAsync(long adminId, AdminUpdateDto dto);

    //public Task<bool> UpdateAdminAsync(long adminId, AdminUpdateDto dto);

    //public Task<Admin> GetByPhoneAsync(string phoneNumber);

    //public Task<bool> DeleteAsync(long adminId);

    //public Task<long> CountAsync();

    //public Task<IList<Admin>> SearchAsync(string search, PaginationParams @params);
}
