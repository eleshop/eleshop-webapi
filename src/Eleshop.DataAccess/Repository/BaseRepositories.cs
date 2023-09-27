using Npgsql;

namespace Eleshop.DataAccess.Repository;

public class BaseRepositories
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepositories()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        this._connection = new NpgsqlConnection("Host=localhost; Port=5432; " +
            "Database=ele-shop; User Id=postgres; Password=12345;");
    }
}
