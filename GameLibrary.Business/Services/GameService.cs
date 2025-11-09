using AutoMapper;
using GameLibrary.Domain.DTOs;
using GameLibrary.Domain.Entities;
using GameLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Business.Services
{
    public class GameService(IGameRepository gameRepository, IMapper mapper) : IGameService
    {
        private readonly IGameRepository _gameRepository = gameRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<GameResponseDTO> CreateGameAsync(CreateGameDTO createGameDTO)
        {
            var game = new Game
            {
                SKU = createGameDTO.SKU,
                Title = createGameDTO.Title,
                Description = createGameDTO.Description,
                Platform = createGameDTO.Platform,
                Region = createGameDTO.Region,
                Format = createGameDTO.Format,
                Genre = createGameDTO.Genre,
                Developer = createGameDTO.Developer,
                ReleaseDate = createGameDTO.ReleaseDate
            };

            var createdGame = await _gameRepository.CreateAsync(game);
            return _mapper.Map<GameResponseDTO>(createdGame);
        }

        public async Task<GameResponseDTO> GetGameByIdAsync(string SKU)
        {
            var game = await _gameRepository.GetByIdAsync(SKU);
            if(game == null)
            {
                throw new KeyNotFoundException($"Juego con SKU {SKU} no encontrado.");
            }

            return _mapper.Map<GameResponseDTO>(game);
        }

        public async Task<IEnumerable<GameResponseDTO>> GetAllGamesAsync()
        {
            var games = await _gameRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GameResponseDTO>>(games);
        }
    }
}
