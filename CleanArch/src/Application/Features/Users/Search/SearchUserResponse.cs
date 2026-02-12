using Domain.Entities;

namespace Application.Features.Users.Search;

public sealed record SearchUserResponse(
    string Username,
    bool IsAdmin,
    List<UserSkill> Skills
);