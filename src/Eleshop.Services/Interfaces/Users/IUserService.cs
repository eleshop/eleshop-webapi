﻿using Eleshop.DataAccess.ViewModel;
using Eleshop.Persistance.Dtos.Users;

namespace Eleshop.Services.Interfaces.Users;

public interface IUserService
{
    public Task<UserViewModel> GetByIdAsync(long id);

    public Task<bool> UpdateAsync(long userId, string phone, UserUpdateDto dto);
}
