﻿using Eleshop.Application.Utilities;

namespace Eleshop.DataAccess.Common;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);

}
