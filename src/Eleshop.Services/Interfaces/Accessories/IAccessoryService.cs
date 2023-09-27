using Eleshop.Application.Utilities;
using Eleshop.Domain.Entites.Accessories;
using Eleshop.Persistance.Dtos.Accessories;

namespace Eleshop.Services.Interfaces.Accessories;

public interface IAccessoryService
{
    public Task<bool> CreateAsync(AccessoryCreateDto dto);

    public Task<bool> DeleteAsync(long accessoryId);

    public Task<long> CountAsync();

    public Task<IList<Accessory>> GetAllAsync(PaginationParams @params);

    public Task<Accessory> GetByIdAsync(long accessoryId);

    public Task<bool> UpdateAsync(long accessoryId, AccessoryUpdateDto dto);
}
