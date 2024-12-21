using AutoMapper;
using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreTestApp.Api;

[ApiController]
[Route("Users")]
public class UserController(IUserService userService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var users = await userService.GetAllAsync();
        var usersDto = mapper.Map<IEnumerable<UserProfileDto>>(users);
        return Ok(usersDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserAsync([FromRoute] int id)
    {
        var user = await userService.GetByIdAsync(id);

        var userDto = mapper.Map<UserProfileDto>(user);
        return Ok(userDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddUserAsync([FromBody] CreateUserProfileDto dto)
    {
        var user = new UserModel
        {
            Username = dto.Username,
            Email = dto.Email,
            Phone = dto.Phone,
            PasswordHash = PasswordHasher.HashPassword(dto.Password),
            Role = "User"
        };

        await userService.CreateAsync(user);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAsync([FromRoute] int id, [FromBody] UpdateUserProfileDto dto)
    {
        var user = await userService.GetByIdAsync(id);
        user.Email = dto.Email;
        user.Phone = dto.Phone;
        await userService.UpdateAsync(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync([FromRoute] int id)
    {
        await userService.DeleteAsync(id);
        return NoContent();
    }
}