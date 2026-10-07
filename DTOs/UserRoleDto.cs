namespace Application.DTOs;

public class UserRoleDto
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? FullName { get; set; }

    public string? Gender { get; set; }

    public int UserAppointmentId { get; set; }

    public int RoleId { get; set; }
}