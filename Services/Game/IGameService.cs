using GamesAPI.Models;
using GamesAPI.Core.Services;
using GamesAPI.Dtos;

public interface IGameService : IService<Game, CreateGameDto, UpdateGameDto> {
}