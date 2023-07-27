using BookShop.Domain.Entities.Starts;
using Dapper;
using System.Data.Common;

namespace BookShop.DataAccess.Repositories.Starts;

public class StarsRepository:BaseRepasitory
{
    public async Task<int> CreateAsync(Star entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO stars( user_id, course_id, star) " +
                " VALUES (@UserId, @CourseId, @StarCount);";
            return await _connection.ExecuteAsync(query, entity);

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
