using Eleshop.Application.Exceptions.Users;
using Eleshop.DataAccess.Interfaces.Users;
using Eleshop.DataAccess.ViewModel;
using Eleshop.Persistance.Dtos.Users;
using Eleshop.Persistance.Helpers;
using Eleshop.Services.Interfaces.Auth;
using Eleshop.Services.Interfaces.Common;
using Eleshop.Services.Interfaces.Users;

namespace Eleshop.Services.Services.Users;

public class UserService : IUserService
{
    //private readonly IAdminUserRepository _adminUserRepository;
    private readonly IIdentityService _identity;
    private readonly IUserRepository _repository;
    private readonly IFileService _fileService;

    public UserService(IUserRepository userRepository,
        IFileService fileService //, IAdminUserRepository adminUserRepository
        , IIdentityService identity)
    {
        this._repository = userRepository;
        this._fileService = fileService;
        //this._adminUserRepository = adminUserRepository;
        this._identity = identity;
    }

    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var user = await _repository.GetByIdAsync(_identity.Id);
        if (user == null) throw new UserNotFoundException();
        else return user;
    }

    public async Task<bool> UpdateAsync(long userId, string phone, UserUpdateDto dto)

    {
        var user = await _repository.GetByPhoneAsync(phone);
        if (user is null) throw new UserNotFoundException();

        // update user with new items 
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;

        if (dto.ImagePath is not null)
        {
            // delete old avatar
            //if (user.ImagePath != "avatars\\avatar.png" && user.ImagePath != "Avatars\\avatar.png")
            //{
            var deleteResult = await _fileService.DeleteAvatarAsync(user.ImagePath);
            //    if (deleteResult is false) throw new ImageNotFoundException();
            //}

            // upload new avatar
            string newImagePath = await _fileService.UploadAvatarAsync(dto.ImagePath);

            // parse new path to avatar
            user.ImagePath = newImagePath;
        }
        // else user old avatar is have to save

        var checkPhone = await _repository.GetByPhoneAsync(dto.PhoneNumber);
        //if (checkPhone is null || user.PhoneNumber == dto.PhoneNumber)
        //{
        //    user.PhoneNumber = dto.PhoneNumber;
        //}
        //else throw new UserAlreadyExistsException(dto.PhoneNumber);

        user.PassportSerialNumber = dto.PassportSerialNumber;
        user.BirthDate = dto.BirthDate;
        user.Region = dto.Region;
        user.District = dto.District;
        user.Address = dto.Address;
        user.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(userId, user);

        return dbResult > 0;
    }
}
