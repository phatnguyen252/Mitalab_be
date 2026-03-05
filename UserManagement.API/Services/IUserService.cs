using Backend.DTOs;

namespace Backend.Services;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<PagedResult<UserDto>> GetPagedUsersAsync(int pageNumber, int pageSize);
}