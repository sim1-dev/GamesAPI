using GamesAPI.Models;
using GamesAPI.Core.Services;
using GamesAPI.Dtos;

namespace GamesAPI.Services;

public interface IGameService : IService<Game, CreateGameDto, UpdateGameDto> {
}