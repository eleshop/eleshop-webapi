using AutoMapper;
using Eleshop.Application.Exceptions.Files;
using Eleshop.Application.Exceptions.Laptops;
using Eleshop.Application.Utilities;
using Eleshop.DataAccess.Interfaces.Laptops;
using Eleshop.Domain.Entites.Laptops;
using Eleshop.Persistance.Dtos.Laptops;
using Eleshop.Persistance.Helpers;
using Eleshop.Services.Interfaces.Auth;
using Eleshop.Services.Interfaces.Common;
using Eleshop.Services.Interfaces.Laptops;

namespace Eleshop.Services.Services.Laptops;

public class LaptopService : ILaptopService
{
    private readonly IIdentityService _identity;
    private readonly ILaptopRepository _repository;
    private readonly IFileService _fileService;
    private readonly IPaginator _paginator;
    private readonly IMapper _mapper;

    public LaptopService(ILaptopRepository laptopRepository,
        IPaginator paginator,
        IFileService fileService,
        IMapper mapper,
        IIdentityService identity)
    {
        this._repository = laptopRepository;
        this._paginator = paginator;
        this._fileService = fileService;
        this._mapper = mapper;
        this._identity = identity;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(LaptopCreateDto dto)
    {
        Laptop laptop = _mapper.Map<Laptop>(dto);
        laptop.CreatedAt = laptop.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.CreateAsync(laptop);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long laptopId)
    {
        var laptop = await _repository.GetByIdAsync(laptopId);
        if (laptop == null) throw new LaptopNotFoundException();

        var dbResult = await _repository.DeleteAsync(laptopId);

        return dbResult > 0;
    }

    public async Task<IList<Laptop>> GetAllAsync(PaginationParams @params)
    {
        var laptop = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return laptop;
    }

    public async Task<Laptop> GetByIdAsync(long laptopId)
    {
        var laptop = await _repository.GetByIdAsync(laptopId);
        if (laptop is null) throw new LaptopNotFoundException();
        else return laptop;
    }

    public async Task<bool> UpdateAsync(long laptopId, LaptopUpdateDto dto)
    {
        var laptop = await _repository.GetByIdAsync(laptopId);
        if (laptop is null) throw new LaptopNotFoundException();

        // update laptop with new items 
        laptop.Name = dto.Name;
        laptop.UnitPrice = dto.UnitPrice;
        laptop.Description = dto.Description;
        laptop.UpdatedAt = TimeHelper.GetDateTime();
        laptop.Core = dto.Core;
        laptop.Company = dto.Company;
        laptop.Cpu = dto.Cpu;
        laptop.CpuHz = dto.CpuHz;
        laptop.Ram = dto.Ram;
        laptop.Ssd = dto.Ssd;
        laptop.Os = dto.Os;
        laptop.OsVersion = dto.OsVersion;
        laptop.UserId = dto.UserId;
        if (dto.ImagePath is not null)
        {
            // delete old image
            var deleteResult = await _fileService.DeleteImageAsync(laptop.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            // upload new image
            string newImagePath = await _fileService.UploadImageAsync(dto.ImagePath);

            // parse new path to laptop
            laptop.ImagePath = newImagePath;
        }
        var dbResult = await _repository.UpdateAsync(laptopId, laptop);

        return dbResult > 0;
    }
}
