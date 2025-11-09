using GameLibrary.Business.Services;
using GameLibrary.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameService gameService, ILogger<GamesController> logger) : ControllerBase
    {
        private readonly IGameService _gameService = gameService;
        private readonly ILogger<GamesController> _logger = logger;

        [HttpPost]
        public async Task<ActionResult<GameResponseDTO>> CreateGame([FromBody] CreateGameDTO createGameDTO)
        {
            try
            {
                _logger.LogInformation("Creando juego nuevo: {Title}", createGameDTO.Title);

                var game = await _gameService.CreateGameAsync(createGameDTO);
                return CreatedAtAction(nameof(GetGameById), new { SKU = game.SKU }, game);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error interno al crear el juego.");
                return StatusCode(500, new { message = "Error interno del servidor."});
            }
        }

        [HttpGet("{SKU}")]
        public async Task<ActionResult<GameResponseDTO>> GetGameById(string SKU)
        {
            try
            {
                var game = await _gameService.GetGameByIdAsync(SKU);
                return Ok(game);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameResponseDTO>>> GetAllGames()
        {
            var games = await _gameService.GetAllGamesAsync();
            return Ok(games);
        }
    }
}
