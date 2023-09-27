using Eleshop.Application.Utilities;
using Eleshop.Domain.Entites.Laptops;
using Eleshop.Persistance.Dtos.Laptops;

namespace Eleshop.Services.Interfaces.Laptops;

public interface ILaptopService
{
    public Task<bool> CreateAsync(LaptopCreateDto dto);

    public Task<bool> DeleteAsync(long laptopId);

    public Task<long> CountAsync();

    public Task<IList<Laptop>> GetAllAsync(PaginationParams @params);

    public Task<Laptop> GetByIdAsync(long laptopId);

    public Task<bool> UpdateAsync(long laptopId, LaptopUpdateDto dto);
}
