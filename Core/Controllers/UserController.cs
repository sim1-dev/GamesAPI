using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GamesAPI.Core.Services;
using GamesAPI.Core.Dtos;
using GamesAPI.Core.Models;

namespace GamesAPI.Controllers;

[Route("api/[controller]s"), Authorize(Roles = "Admin")]
public class UserController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserController(IMapper mapper, IUserService userService) {
        this._mapper = mapper;
        this._userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<Collection<UserDto>>> Get([FromQuery] RequestFilter[]? filters = null, [FromQuery] RequestOrder? order = null, [FromQuery] RequestPagination? pagination = null) {
        List<User> users = (await this._userService.Get(filters, order, pagination)).ToList();

        List<UserDto> userDtos = _mapper.Map<List<UserDto>>(users);

        return Ok(userDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDetailDto>> Find(int id) {
        User? user = await this._userService.Find(id);

        if(user is null)
            return NotFound();

        UserDetailDto userDetailDto = _mapper.Map<UserDetailDto>(user);

        return Ok(userDetailDto);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Create([FromBody]CreateUserDto createUserDto) {
        User user = await this._userService.Create(createUserDto);

        UserDto userDto = _mapper.Map<UserDto>(user);

        return Ok(userDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> Update(int id, [FromBody]UpdateUserDto updateUserDto) {
        User? user = await this._userService.Update(id, updateUserDto);

        if(user is null)
            return NotFound();

        UserDto userDto = _mapper.Map<UserDto>(user);

        return Ok(userDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id) {
        User? user = await this._userService.Find(id);

        if(user is null)
            return NotFound();

        await this._userService.Delete(id);

        return Ok();
    }
}