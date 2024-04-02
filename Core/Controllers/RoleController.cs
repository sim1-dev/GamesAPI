using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GamesAPI.Core.Services;
using GamesAPI.Core.Dtos;
using GamesAPI.Core.Models;

namespace GamesAPI.Controllers;

[Route("api/[controller]s"), Authorize(Roles = "Admin")]
public class RoleController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly IRoleService _roleService;

    public RoleController(IMapper mapper, IRoleService roleService) {
        this._mapper = mapper;
        this._roleService = roleService;
    }

    [HttpGet]
    public async Task<ActionResult<Collection<RoleDto>>> Get([FromQuery] RequestFilter[]? filters = null, [FromQuery] RequestOrder? order = null, [FromQuery] RequestPagination? pagination = null) {
        List<Role> roles = (await this._roleService.Get(filters, order, pagination)).ToList();

        List<RoleDto> roleDtos = _mapper.Map<List<RoleDto>>(roles);

        return Ok(roleDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoleDetailDto>> Find(int id) {
        Role? role = await this._roleService.Find(id);

        if(role is null)
            return NotFound();

        RoleDetailDto roleDetailDto = _mapper.Map<RoleDetailDto>(role);

        return Ok(roleDetailDto);
    }

    [HttpPost]
    public async Task<ActionResult<RoleDto>> Create([FromBody]CreateRoleDto createRoleDto) {
        Role role = await this._roleService.Create(createRoleDto);

        RoleDto roleDto = _mapper.Map<RoleDto>(role);

        return Ok(roleDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RoleDto>> Update(int id, [FromBody]UpdateRoleDto updateRoleDto) {
        Role? role = await this._roleService.Update(id, updateRoleDto);

        if(role is null)
            return NotFound();

        RoleDto roleDto = _mapper.Map<RoleDto>(role);

        return Ok(roleDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id) {
        Role? role = await this._roleService.Find(id);

        if(role is null)
            return NotFound();

        await this._roleService.Delete(id);

        return Ok();
    }
}