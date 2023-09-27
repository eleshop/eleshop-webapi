using Dapper;
using Eleshop.Application.Utilities;
using Eleshop.DataAccess.Interfaces.Accessories;
using Eleshop.Domain.Entites.Accessories;

namespace Eleshop.DataAccess.Repository.Accessories;

public class AccessoryRepository : BaseRepositories, IAccessuaryRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select Count(*) From accessories";
            var result = await _connection.QuerySingleAsync<long>(query);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Accessory entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.accessories(category_id, user_id, name, unit_price, image_path, description, created_at, updated_at) " +
                "VALUES (@CategoryId, @UserId, @Name, @UnitPrice, @ImagePath, @Description, @CreatedAt, @UpdatedAt);";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM accessories WHERE id=@Id;";
            var result = await _connection.ExecuteAsync(query, new { Id = id });

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Accessory>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "Select * From accessories Order By id Desc " +
                $"Offset {@params.GetSkipCount()} Limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Accessory>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Accessory>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Accessory?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select * From accessories Where id=@Id";
            var result = await _connection.QuerySingleAsync<Accessory>(query, new { Id = id });

            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Accessory entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE public.accessories SET name=@Name, unit_price=@UnitPrice, image_path=@ImagePath, " +
                "description=@Description, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                $"WHERE id={id};";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
