using Application.DTOs;
using Application.Interfaces;

namespace Application.Services;

public class UserService
{
    private readonly IUserRepository _users;

    public UserService(IUserRepository users)
    {
        _users = users;
    }

    public async Task<List<UserRoleDto>> GetByNameAsync(
        string? userName,
        string? fullName,
        CancellationToken cancellationToken = default)
    {
        // ცარიელი ან მხოლოდ გამოტოვებების შემცველი ტექსტი ხდება null.
        userName = Normalize(userName);
        fullName = Normalize(fullName);

        // ორივე ცარიელია ან ორივე შევსებულია.
        if ((userName is null) == (fullName is null))
        {
            throw new ArgumentException(
                "შეავსე მხოლოდ ერთი: userName ან fullName.");
        }

        return await _users.GetByNameAsync(
            userName,
            fullName,
            cancellationToken);
    }

    private static string? Normalize(string? value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? null
            : value.Trim();
    }
}