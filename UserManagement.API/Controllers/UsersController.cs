using Microsoft.AspNetCore.Mvc;
using Backend.Services;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
    {
        if (pageNumber.HasValue && pageSize.HasValue)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest(new { message = "PageNumber và PageSize phải lớn hơn 0" });
            }

            var pagedResult = await _userService.GetPagedUsersAsync(pageNumber.Value, pageSize.Value);
            return Ok(pagedResult);
        }

        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }
}