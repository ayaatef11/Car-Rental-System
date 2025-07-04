﻿namespace Car_Rental_System.Infrastructure.Repositories;
    public class UnitOfwork(AppDbContext _storeContext):IUnitOfWork
    {
        private readonly Hashtable _repositories = [];
        private bool _disposed = false;
        //
        public IGenericRepository<T> Repository<T>() where T : class
        {
            var key = typeof(T).Name;

            if (!_repositories.ContainsKey(key))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _storeContext);

                _repositories.Add(key, repository);
            }

            return (GenericRepository<T>)_repositories[key]!;
        }

    
        public async Task<int> CompleteAsync() => await _storeContext.SaveChangesAsync();


        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (_storeContext != null)
            {
                await _storeContext.DisposeAsync();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _storeContext?.Dispose();
                }

                _disposed = true;
            }
        }

    public Task<int> SaveChangesAsync()
    {
      return  _storeContext.SaveChangesAsync();
    }

  
    ~UnitOfwork()
        {
            Dispose(false);
        }
    }
