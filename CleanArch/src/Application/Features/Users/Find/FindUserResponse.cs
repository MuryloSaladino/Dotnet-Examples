using Domain.Entities;

namespace Application.Features.Users.Find;

public sealed record FindUserResponse(
    string Username,
    bool IsAdmin,
    List<UserSkill> Skills
);