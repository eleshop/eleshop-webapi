using Dapper;
using Eleshop.Application.Utilities;
using Eleshop.DataAccess.Interfaces.Heads;
using Eleshop.DataAccess.ViewModel;
using Eleshop.Domain.Entites.Users;

namespace Eleshop.DataAccess.Repository.Heads;

public class HeadRepository : BaseRepositories, IHeadRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select Count(*) From users" +
                "where role = 3";
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

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.users(first_name, last_name, phone_number, phone_number_confirmed, " +
                "password_hash, salt, image_path, passport_serial_number, " +
                    "birth_date, region, district, address, role, created_at, updated_at) " +
                "VALUES (@FirstName, @LastName, @PhoneNumber, @PhoneNumberConfirmed, " +
                    "@PasswordHash, @Salt, @ImagePath, @PassportSerialNumber, @BirthDate, " +
                        "@Region, @District, @Address, @IdentityRole, @CreatedAt, @UpdatedAt);";

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
            string query = "DELETE FROM public.users WHERE role=3 and id=@Id;";
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

    public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM public.users " +
                "where role = 3 Order By id Desc " +
                $"Offset {@params.GetSkipCount()} Limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<UserViewModel>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<UserViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<UserViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select * From users where id=@Id and role=3";
            var result = await _connection.QuerySingleAsync<UserViewModel>(query, new { Id = id });

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

    public async Task<User?> GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users WHERE phone_number = @PhoneNumber and role = 3";
            var data = await _connection.QuerySingleAsync<User>(query, new { PhoneNumber = phone });
            return data;
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

    public async Task<(long ItemsCount, IList<UserViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"Select * From users Where role = 3 and first_name ILIKE @search Order By first_name " +
                $"Offset {@params.GetSkipCount()} Limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<UserViewModel>(query, new { search = "%" + search + "%" })).ToList();
            long count = result.LongCount();

            return (count, result);
        }
        catch
        {
            return (0, new List<UserViewModel>());
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE public.users SET " +
                "first_name=@FirstName, last_name=@LastName, phone_number=@PhoneNumber, phone_number_confirmed=@PhoneNumberConfirmed, " +
                    "password_hash=@PasswordHash, salt=@Salt, image_path=@ImagePath, passport_serial_number=@PassportSerialNumber, " +
                        "birth_date=@BirthDate, region=@Region, district=@District, address=@Address, role=@IdentityRole created_at=@CreatedAt, updated_at=@UpdatedAt " +
                $"WHERE role=3 and id={id};";

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
