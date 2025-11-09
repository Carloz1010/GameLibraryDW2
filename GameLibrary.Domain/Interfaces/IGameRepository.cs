using GameLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Domain.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> GetByIdAsync(string sku);
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game> CreateAsync(Game game);
        Task UpdateAsync(Game game);
        Task DeleteAsync(string sku);
    }
}
