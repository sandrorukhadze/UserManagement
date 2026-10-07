using Application.DTOs;

namespace Application.Interfaces;

public interface IUserRepository
{
    Task<List<UserRoleDto>> GetByNameAsync(
        string? userName,
        string? fullName,
        CancellationToken cancellationToken = default);
}