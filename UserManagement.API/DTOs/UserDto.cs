using Backend.Models;

namespace Backend.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CreatedAt { get; set; } = string.Empty;

    // Mapping method
    public static UserDto FromUser(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            CreatedAt = user.CreatedAt.ToString("dd/MM/yyyy HH:mm")
        };
    }
}