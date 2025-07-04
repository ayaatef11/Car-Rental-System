﻿namespace Car_Rental_System.Application.Common.Interfaces;
public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id, params string[] includes);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<(IEnumerable<T> Items, int Count)> GetAllAsync(
        Expression<Func<T, bool>> filter = null,
        string[]? includes = null,string? sortColumn = null,string? sortOrder = null,int? pageNumber = null,int? pageSize = null);

    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void Delete(T entity);
    Task<int> CountAsync(Expression<Func<T, bool>>? filter = null);
    Task<T?> GetSingleOrDefaultAsync(Expression<Func<T, bool>> filter, string[]? includes = null);
    T Get(int id);
    Task<T?> GetByIdWithSpecAsync(ISpecifications<T> spec);
    Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec);
    Task<int> GetCountAsync(ISpecifications<T> spec);
}
