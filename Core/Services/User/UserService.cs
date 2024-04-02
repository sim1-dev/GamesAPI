using AutoMapper;
using GamesAPI.Core.Models;
using GamesAPI.Core.Repositories;
using GamesAPI.Core.Dtos;

namespace GamesAPI.Core.Services;

public class UserService : IUserService {
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper) {
        this._userRepository = userRepository;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<User>> Get(RequestFilter[]? filters, RequestOrder? order, RequestPagination? pagination) {
        IEnumerable<User> users = await this._userRepository.Get(filters, order, pagination);
        return users;
    }

    public async Task<User?> Find(int id) {
        User? user = await this._userRepository.Find(id);

        return user;
    }

    public async Task<User> Create(CreateUserDto createUserDto) {
        User user = this._mapper.Map<User>(createUserDto);

        if(createUserDto.Password is null)
            await this._userRepository.Create(user);
        else
            await this._userRepository.CreateWithPassword(user, createUserDto.Password);

        return user;
    }

    public async Task<User?> Update(int id, UpdateUserDto updateUserDto) {
        User? user = await this._userRepository.Find(id);

        if(user is null)
            return null;

        User updatedUser = _mapper.Map(updateUserDto, user);

        if(updateUserDto.Password is null)
            await this._userRepository.Update(updatedUser);
        else
            await this._userRepository.UpdateWithPassword(updatedUser, updateUserDto.Password);

        return user;
    }

    public async Task<bool> Delete(int id) {
        User? user = await this._userRepository.Find(id);

        if(user is null)
            return false;

        await this._userRepository.Delete(user);

        return true;
    }
}