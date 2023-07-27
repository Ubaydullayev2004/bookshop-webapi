using BookShop.DataAccess.Interfaces.Users;
using BookShop.DataAccess.Utils;
using BookShop.DataAccess.ViewModel.Users;
using BookShop.Domain.Entities.Users;
using Dapper;

namespace BookShop.DataAccess.Repositories.Users;

public class UserRepository : BaseRepasitory, IUserRepasitory
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select counts(*) from users";
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
            string query = "INSERT INTO public.users(first_name, last_name, phone_number, phone_number_confirmed, passport_seria_number, is_male, birth_date, country, region, password_hash, salt, image_path, last_activity, identity_role, created_at, updated_at) " +
                $"VALUES (@FirstName, @LastName, @PhoneNumber, @PhoneNumberConfirmed, @PassportSeriaNumber, @IsMale, '{entity.BirthDate.Year}-{entity.BirthDate.Month}-{entity.BirthDate.Day}', @Country, @Region, @PasswordHash, @Salt, @ImagePath, @LastActivity, @IdentityRole, @CreatedAt, @UpdatedAt);";
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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"delete from users where id = {id}";
            return await _connection.ExecuteAsync(query);
        }
        catch (Exception)
        {
            return 0;
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
            string query = "SELECT * FROM users where phone_number = @PhoneNumber";
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

    public Task<UserViewModel?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<(int ItemsCount, IList<User>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE users " +
                "SET first_name = @FirstName, last_name = @LastName, email = @Email, email_confirmed = @EmailConfirmed, phone_number = @PhoneNumber, " +
                "balance = @Balance, avatar_path = @AvatarPath, password_hash = @PasswordHash, salt = @Salt, " +
                "identity_role = @IdentityRole, updated_at = @UpdatedAt, is_delated = @IsDetated " +
                $"WHERE id = {id};";
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
    
    public async Task<IList<User>> GetAllAsync(PaginationParams @params)
    {

        try
        {
            await _connection.OpenAsync();
            string query = $"select * from users " +
                $"order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<User>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<User>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    
}
