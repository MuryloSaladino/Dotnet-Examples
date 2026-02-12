using Domain.Common;
using Infrastructure.Persistence.Context;
using Application.Data;

namespace Infrastructure.Persistence.Repository;

public class BaseRepository<TEntity>(SkillsContext context)
    : IBaseRepository<TEntity>
        where TEntity : class
{
    protected SkillsContext Context = context;

    public void Create(TEntity entity)
        => Context.Add(entity);

    public void Update(TEntity entity)
    {
        if (entity is BaseEntity baseEntity)
            baseEntity.UpdatedAt = DateTime.UtcNow;
        Context.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.DeletedAt = DateTime.UtcNow;
            Context.Update(baseEntity);
        }
        else Context.Remove(entity);
    }
}
