using Eleshop.Application.Utilities;
using Eleshop.Domain.Entites.Accessories;
using Eleshop.Domain.Entites.Telephones;
using Eleshop.Persistance.Dtos.Accessories;
using Eleshop.Persistance.Dtos.Telephones;

namespace Eleshop.Services.Interfaces.Telephones;

public interface ITelephoneService
{
    public Task<bool> CreateAsync(TelephoneCreateDto dto);

    public Task<bool> DeleteAsync(long telephoneId);

    public Task<long> CountAsync();

    public Task<IList<Telephone>> GetAllAsync(PaginationParams @params);

    public Task<Telephone> GetByIdAsync(long telephoneId);

    public Task<bool> UpdateAsync(long telephoneId, TelephoneUpdateDto dto);
}
