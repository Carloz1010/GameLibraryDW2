using GameLibrary.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Business.Services
{
    public interface IGameService
    {
        Task<GameResponseDTO> CreateGameAsync(CreateGameDTO createGameDTO);
        Task<GameResponseDTO> GetGameByIdAsync(string SKU);

        Task<IEnumerable<GameResponseDTO>> GetAllGamesAsync();
    }
}
