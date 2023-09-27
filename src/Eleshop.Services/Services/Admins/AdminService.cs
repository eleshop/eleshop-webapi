using Eleshop.Application.Exceptions.Admins;
using Eleshop.DataAccess.Interfaces.Admins;
using Eleshop.DataAccess.ViewModel;
using Eleshop.Persistance.Dtos.Users;
using Eleshop.Persistance.Helpers;
using Eleshop.Services.Interfaces.Admins;
using Eleshop.Services.Interfaces.Auth;
using Eleshop.Services.Interfaces.Common;

namespace Eleshop.Services.Services.Admins;

public class AdminService : IAdminService
{
    //private readonly IAdminUserRepository _adminUserRepository;
    private readonly IIdentityService _identity;
    private readonly IAdminRepository _repository;
    private readonly IFileService _fileService;

    public AdminService(IAdminRepository adminRepository,
        IFileService fileService //, IAdminUserRepository adminUserRepository
        , IIdentityService identity)
    {
        this._repository = adminRepository;
        this._fileService = fileService;
        //this._adminUserRepository = adminUserRepository;
        this._identity = identity;
    }

    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var admin = await _repository.GetByIdAsync(_identity.Id);
        if (admin == null) throw new AdminNotFoundException();
        else return admin;
    }

    public async Task<bool> UpdateAsync(long adminId, string phone, UserUpdateDto dto)

    {
        var admin = await _repository.GetByPhoneAsync(phone);
        if (admin is null) throw new AdminNotFoundException();

        // update user with new items 
        admin.FirstName = dto.FirstName;
        admin.LastName = dto.LastName;

        if (dto.ImagePath is not null)
        {
            // delete old avatar
            //if (user.ImagePath != "avatars\\avatar.png" && user.ImagePath != "Avatars\\avatar.png")
            //{
            var deleteResult = await _fileService.DeleteAvatarAsync(admin.ImagePath);
            //    if (deleteResult is false) throw new ImageNotFoundException();
            //}

            // upload new avatar
            string newImagePath = await _fileService.UploadAvatarAsync(dto.ImagePath);

            // parse new path to avatar
            admin.ImagePath = newImagePath;
        }
        // else user old avatar is have to save

        var checkPhone = await _repository.GetByPhoneAsync(dto.PhoneNumber);
        //if (checkPhone is null || user.PhoneNumber == dto.PhoneNumber)
        //{
        //    user.PhoneNumber = dto.PhoneNumber;
        //}
        //else throw new UserAlreadyExistsException(dto.PhoneNumber);

        admin.PassportSerialNumber = dto.PassportSerialNumber;
        admin.BirthDate = dto.BirthDate;
        admin.Region = dto.Region;
        admin.District = dto.District;
        admin.Address = dto.Address;
        admin.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(adminId, admin);

        return dbResult > 0;
    }
}
