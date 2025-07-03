namespace Car_Rental_System.Application.Common.Interfaces;

public interface IUnitOfWork : IAsyncDisposable, IDisposable
{
    IGenericRepository<T> Repository<T>() where T : class;
    Task<int> CompleteAsync();
    Task<int> SaveChangesAsync();
}