using System;
using FutrexConnect.Domain.Entities;

namespace FutrexConnect.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(long id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        void DeleteAsync(T entity);
    }
}
