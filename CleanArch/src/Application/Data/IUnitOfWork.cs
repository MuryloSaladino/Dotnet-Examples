namespace Application.Data;

public interface IUnitOfWork
{
    Task Save(CancellationToken cancellationToken);
}