using Eleshop.Application.Utilities;

namespace Eleshop.Services.Interfaces.Common;

public interface IPaginator
{
    public void Paginate(long ItemsCount, PaginationParams @params);
}
