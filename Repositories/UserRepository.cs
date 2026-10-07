using System.Data;
using Application.DTOs;
using Application.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<UserRoleDto>> GetByNameAsync(
        string? userName,
        string? fullName,
        CancellationToken cancellationToken = default)
    {
        // მეთოდის დასრულებისას კავშირი ავტომატურად გათავისუფლდება.
        await using var connection =
            new SqlConnection(_connectionString);

        await connection.OpenAsync(cancellationToken);

        var command = new CommandDefinition(
            commandText: "[users].[GetUsersByName]",
            parameters: new
            {
                UserName = userName,
                FullName = fullName
            },
            commandType: CommandType.StoredProcedure,
            cancellationToken: cancellationToken);

        var users = await connection
            .QueryAsync<UserRoleDto>(command);

        return users.ToList();
    }
}