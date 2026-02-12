using Domain.Entities;

namespace Application.Features.Users.Search;

public sealed record SearchUserResponse(
    string Username,
    List<UserSkill> Skills
);