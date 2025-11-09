using GameLibrary.Domain.Entities;
using GameLibrary.Domain.Interfaces;
using GameLibrary.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Infraestructure.Repositories
{
    public class GameRepository(AppDbContext context) : IGameRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Game> CreateAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task DeleteAsync(string sku)
        {
            var game = await _context.Games.FindAsync(sku);
            if(game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetByIdAsync(string sku)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.SKU == sku);

            return game!;
        }

        public async Task UpdateAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }
    }
}
