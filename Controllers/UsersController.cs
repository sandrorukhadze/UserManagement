using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserRoleDto>>> GetByName(
        [FromQuery] string? userName,
        [FromQuery] string? fullName,
        CancellationToken cancellationToken)
    {
        try
        {
            var users = await _userService.GetByNameAsync(
                userName,
                fullName,
                cancellationToken);

            return Ok(users);
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new
            {
                message = exception.Message
            });
        }
    }
}