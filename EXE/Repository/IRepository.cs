﻿using System.Linq.Expressions;

namespace Models.Repository
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> AddOneItem(T item);
        Task<List<T>> AddManyItem(List<T> items);
        Task<bool> RemoveItemByValue(string id);
        Task<T> UpdateItemByValue(string id, T replacement);
        Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> filterExpression);

        Task<IEnumerable<T>> GetPagedAsync(int skip, int pageSize, bool isAsc, string sortField);
        Task<long> CountAsync();
    }
}
