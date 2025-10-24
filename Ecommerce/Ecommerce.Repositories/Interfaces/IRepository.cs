using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Interfaces
{
    /// <summary>
    /// Interfaccia generica che definisce le operazioni CRUD di base
    /// per la gestione delle entità nel database.
    /// </summary>
    /// <typeparam name="T">Tipo dell'entità gestita dal repository.</typeparam>
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
