using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    public required string Username { get; set; }
    public List<UserSkill> Skills { get; set; } = [];
}
