using Backend.DTOs;
using Backend.Repositories;

namespace Backend.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(UserDto.FromUser);
    }

    public async Task<PagedResult<UserDto>> GetPagedUsersAsync(int pageNumber, int pageSize)
    {
        var (users, totalCount) = await _userRepository.GetPagedAsync(pageNumber, pageSize);
        
        return new PagedResult<UserDto>
        {
            Items = users.Select(UserDto.FromUser).ToList(),
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }
}