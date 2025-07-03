namespace Car_Rental_System.Infrastructure.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public AppDbContext _context { get; set; }
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();

    }
    public async Task<T?> GetByIdAsync(int id, params string[] includes)
    {
        var query = _dbSet.AsQueryable();

        query = query.ApplyIncludes(includes);

        return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<(IEnumerable<T> Items, int Count)> GetAllAsync(Expression<Func<T, bool>> filter = null,
        string[]? includes = null, string? sortColumn = null, string? sortOrder = null, int? pageNumber = null, int? pageSize = null)
    {
        var query = _dbSet.AsQueryable();

        query = query.ApplyIncludes(includes);

        if (filter != null)
            query = query.Where(filter);

        var count = await query.CountAsync();

        query = query.ApplySorting(sortColumn, sortOrder);
        query = query.ApplyPaging(pageNumber, pageSize);

        var items = await query.ToListAsync();

        return (items, count);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();

    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? filter = null)
    {
        return await _dbSet.CountAsync(filter ?? (_ => true));
    }


    public async Task<T?> GetSingleOrDefaultAsync(Expression<Func<T, bool>> filter, string[]? includes = null)
    {
        var query = _dbSet.AsQueryable();
        query = query.ApplyIncludes(includes);
        return await query.SingleOrDefaultAsync(filter);
    }
    public void Add(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();

    }

    public T Get(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public T update(T entity)
    {

        _context.Set<T>().Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();

    }
}

