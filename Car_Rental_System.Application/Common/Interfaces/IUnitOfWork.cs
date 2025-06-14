
namespace Car_Rental_System.Application.Common.Interfaces;
public interface IUnitOfWork : IDisposable
{
    //IRepository<Car> Cars { get; }
   
    Task<int> SaveChangesAsync();
}