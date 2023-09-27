using AutoMapper;
using Eleshop.Application.Exceptions.Files;
using Eleshop.Application.Exceptions.Telephones;
using Eleshop.Application.Utilities;
using Eleshop.DataAccess.Interfaces.Telephones;
using Eleshop.Domain.Entites.Telephones;
using Eleshop.Persistance.Dtos.Telephones;
using Eleshop.Persistance.Helpers;
using Eleshop.Services.Interfaces.Auth;
using Eleshop.Services.Interfaces.Common;
using Eleshop.Services.Interfaces.Telephones;

namespace Eleshop.Services.Services.Telephones;

public class TelephoneService : ITelephoneService
{
    private readonly IIdentityService _identity;
    private readonly ITelephoneRepository _repository;
    private readonly IFileService _fileService;
    private readonly IPaginator _paginator;
    private readonly IMapper _mapper;

    public TelephoneService(ITelephoneRepository telephoneRepository,
        IPaginator paginator,
        IFileService fileService,
        IMapper mapper,
        IIdentityService identity)
    {
        this._repository = telephoneRepository;
        this._paginator = paginator;
        this._fileService = fileService;
        this._mapper = mapper;
        this._identity = identity;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(TelephoneCreateDto dto)
    {
        Telephone telephone = _mapper.Map<Telephone>(dto);
        telephone.CreatedAt = telephone.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.CreateAsync(telephone);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long telephoneId)
    {
        var telephone = await _repository.GetByIdAsync(telephoneId);
        if (telephone == null) throw new TelephonyNotFoundException();

        var dbResult = await _repository.DeleteAsync(telephoneId);

        return dbResult > 0;
    }

    public async Task<IList<Telephone>> GetAllAsync(PaginationParams @params)
    {
        var telephone = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return telephone;
    }

    public async Task<Telephone> GetByIdAsync(long telephoneId)
    {
        var telephone = await _repository.GetByIdAsync(telephoneId);
        if (telephone is null) throw new TelephonyNotFoundException();
        else return telephone;
    }

    public async Task<bool> UpdateAsync(long telephoneId, TelephoneUpdateDto dto)
    {
        var telephone = await _repository.GetByIdAsync(telephoneId);
        if (telephone is null) throw new TelephonyNotFoundException();

        // update telephone with new items 
        telephone.Name = dto.Name;
        telephone.UnitPrice = dto.UnitPrice;
        telephone.Description = dto.Description;
        telephone.UpdatedAt = TimeHelper.GetDateTime();
        telephone.Company = dto.Company;
        telephone.Ram = dto.Ram;
        telephone.Memory = dto.Memory;
        telephone.Version = dto.Version;
        telephone.UserId = dto.UserId;
        if (dto.ImagePath is not null)
        {
            // delete old image
            var deleteResult = await _fileService.DeleteImageAsync(telephone.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            // upload new image
            string newImagePath = await _fileService.UploadImageAsync(dto.ImagePath);

            // parse new path to telephone
            telephone.ImagePath = newImagePath;
        }
        var dbResult = await _repository.UpdateAsync(telephoneId, telephone);

        return dbResult > 0;
    }
}
