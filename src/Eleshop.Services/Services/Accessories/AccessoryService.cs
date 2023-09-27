using AutoMapper;
using Eleshop.Application.Exceptions.Accessories;
using Eleshop.Application.Exceptions.Files;
using Eleshop.Application.Utilities;
using Eleshop.DataAccess.Interfaces.Accessories;
using Eleshop.Domain.Entites.Accessories;
using Eleshop.Persistance.Dtos.Accessories;
using Eleshop.Persistance.Helpers;
using Eleshop.Services.Interfaces.Accessories;
using Eleshop.Services.Interfaces.Auth;
using Eleshop.Services.Interfaces.Common;

namespace Eleshop.Services.Services.Accessories;

public class AccessoryService : IAccessoryService
{
    private readonly IIdentityService _identity;
    private readonly IAccessuaryRepository _repository;
    private readonly IFileService _fileService;
    private readonly IPaginator _paginator;
    private readonly IMapper _mapper;

    public AccessoryService(IAccessuaryRepository accessuaryRepository,
        IPaginator paginator,
        IFileService fileService,
        IMapper mapper,
        IIdentityService identity)
    {
        this._repository = accessuaryRepository;
        this._paginator = paginator;
        this._fileService = fileService;
        this._mapper = mapper;
        this._identity = identity;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(AccessoryCreateDto dto)
    {
        Accessory accessory = _mapper.Map<Accessory>(dto);
        accessory.CreatedAt = accessory.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.CreateAsync(accessory);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long accessoryId)
    {
        var accessory = await _repository.GetByIdAsync(accessoryId);
        if (accessory == null) throw new AccessoryNotFoundException();

        var dbResult = await _repository.DeleteAsync(accessoryId);

        return dbResult > 0;
    }

    public async Task<IList<Accessory>> GetAllAsync(PaginationParams @params)
    {
        var accessory = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return accessory;
    }

    public async Task<Accessory> GetByIdAsync(long accessoryId)
    {
        var accessory = await _repository.GetByIdAsync(accessoryId);
        if (accessory is null) throw new AccessoryNotFoundException();
        else return accessory;
    }

    public async Task<bool> UpdateAsync(long accessoryId, AccessoryUpdateDto dto)
    {
        var accessory = await _repository.GetByIdAsync(accessoryId);
        if (accessory is null) throw new AccessoryNotFoundException();

        // update accessory with new items 
        accessory.Name = dto.Name;
        accessory.UnitPrice = dto.UnitPrice;
        accessory.Description = dto.Description;
        accessory.UpdatedAt = TimeHelper.GetDateTime();
        accessory.UserId = dto.UserId;
        if (dto.ImagePath is not null)
        {
            // delete old image
            var deleteResult = await _fileService.DeleteImageAsync(accessory.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            // upload new image
            string newImagePath = await _fileService.UploadImageAsync(dto.ImagePath);

            // parse new path to accessory
            accessory.ImagePath = newImagePath;
        }
        var dbResult = await _repository.UpdateAsync(accessoryId, accessory);

        return dbResult > 0;
    }
}
