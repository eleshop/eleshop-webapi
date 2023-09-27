using Eleshop.Application.Utilities;

namespace Eleshop.DataAccess.Common;

public interface ISearchable<TModel>
{
    public Task<(long ItemsCount, IList<TModel>)> SearchAsync(string search, PaginationParams @params);
}
