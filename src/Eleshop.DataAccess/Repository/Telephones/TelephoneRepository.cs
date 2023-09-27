using Dapper;
using Eleshop.Application.Utilities;
using Eleshop.DataAccess.Interfaces.Telephones;
using Eleshop.Domain.Entites.Telephones;

namespace Eleshop.DataAccess.Repository.Telephones;

public class TelephoneRepository : BaseRepositories, ITelephoneRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select Count(*) From telephones";
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

    public async Task<int> CreateAsync(Telephone entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.telephones(category_id, user_id, name, " +
                "unit_price, image_path, description, company, ram, memory, " +
                "version, created_at, updated_at) " +
                "VALUES (@CategoryId, @UserId, @Name, @UnitPrice, @ImagePath, @Description," +
                "@Company, @Ram, @Memory, @Version, @CreatedAt, @UpdatedAt);";

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
            string query = "DELETE FROM telephones WHERE id=@Id;";
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

    public async Task<IList<Telephone>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "Select * From telephones Order By id Desc " +
                $"Offset {@params.GetSkipCount()} Limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Telephone>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Telephone>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Telephone?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select * From telephones Where id=@Id";
            var result = await _connection.QuerySingleAsync<Telephone>(query, new { Id = id });

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

    public async Task<int> UpdateAsync(long id, Telephone entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE public.telephones SET name=@Name, " +
                "unit_price=@UnitPrice, image_path=@ImagePath, " +
                "description=@Description, company=@Company, ram=@Ram, " +
                "memory=@Memory, version=@Version, created_at=@CreatedAt, " +
                "updated_at=@UpdatedAt " +
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
