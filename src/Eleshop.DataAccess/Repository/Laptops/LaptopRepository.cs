using Dapper;
using Eleshop.Application.Utilities;
using Eleshop.DataAccess.Interfaces.Laptops;
using Eleshop.Domain.Entites.Laptops;

namespace Eleshop.DataAccess.Repository.Laptops;

public class LaptopRepository : BaseRepositories, ILaptopRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select Count(*) From laptops";
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

    public async Task<int> CreateAsync(Laptop entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.laptops(category_id, user_id, name, " +
                "unit_price, description, image_path, core, company, cpu, " +
                "cpuhz, ram, ssd, os, osversion, created_at, updated_at) " +
                "VALUES (@CategoryId, @UserId, @Name, @UnitPrice, @Description, " +
                "@ImagePath, @Core, @Company, @Cpu, @CpuHz, @Ram, @Ssd, @Os, " +
                "@OsVersion, @CreatedAt, @UpdatedAt);";

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
            string query = "DELETE FROM laptops WHERE id=@Id;";
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

    public async Task<IList<Laptop>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "Select * From laptops Order By id Desc " +
                $"Offset {@params.GetSkipCount()} Limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Laptop>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Laptop>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Laptop?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select * From laptops Where id=@Id";
            var result = await _connection.QuerySingleAsync<Laptop>(query, new { Id = id });

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

    public async Task<int> UpdateAsync(long id, Laptop entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE public.laptops SET name=@Name, " +
                "unit_price=@UnitPrice, description=@Description, " +
                "image_path=@ImagePath, core=@Core, company=@Company cpu=@Cpu, " +
                "cpuhz=@CpuHz, ram=@Ram, ssd=@Ssd, os=@Os osversion=@OsVersion " +
                "created_at=@CreatedAt, updated_at=@UpdatedAt " +
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
