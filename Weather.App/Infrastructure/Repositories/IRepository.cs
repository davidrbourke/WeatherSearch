using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Weather.App.Infrastructure.Repositories
{
    public interface IRepository
    {
        Task<IQueryable<TValue>> ReadAsync<TValue>(Expression<Func<TValue, bool>> expression);
        Task<TValue> UpdateAsync<TValue>(TValue value);
        Task<TValue> CreateAsync<TValue>(TValue value);
        Task<bool> DeleteAsync<TValue>(TValue value);
    }
}
