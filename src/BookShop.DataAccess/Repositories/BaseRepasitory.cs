using Npgsql;

namespace BookShop.DataAccess.Repositories;


public class BaseRepasitory
{

    protected readonly NpgsqlConnection _connection;
    public BaseRepasitory()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=e-bookshop-db; User Id=postgres; Password=1204;");
    }

}
