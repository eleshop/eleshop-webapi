using Dapper;
using Eleshop.Application.Utilities;
using Eleshop.DataAccess.Interfaces.Categories;
using Eleshop.Domain.Entites.Categories;
using System.Data.Common;

namespace Eleshop.DataAccess.Repository.Categories;

public class CategoryRepository : BaseRepositories, ICategoryRepasitory
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT COUNT(*) FROM categories";
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

    public async Task<int> CreateAsync(Category entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.categories(user_id, name, created_at, updated_at) " +
                "VALUES (@UserId, @Name, @CreatedAt, @UpdatedAt);";

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
            string query = "DELETE FROM categories WHERE id=@Id";
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

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM categories ORDER BY id DESC " +
                $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize};";

            var result = (await _connection.QueryAsync<Category>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Category>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Category?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM categories WHERE id=@Id";
            var result = await _connection.QuerySingleAsync<Category>(query, new { Id = id });

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

    public async Task<int> UpdateAsync(long id, Category entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.categories " +
                $"SET name=@Name, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                    $"WHERE id={id}";

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
