using AutoMapper;
using GamesAPI.Core.Models;
using GamesAPI.Core.Repositories;
using GamesAPI.Core.Dtos;

namespace GamesAPI.Core.Services;

public class RoleService : IRoleService {
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public RoleService(IRoleRepository roleRepository, IMapper mapper) {
        this._roleRepository = roleRepository;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<Role>> Get(RequestFilter[]? filters, RequestOrder? order) {
        IEnumerable<Role> roles = await this._roleRepository.Get(filters, order);
        return roles;
    }

    public async Task<Role?> Find(int id) {
        Role? role = await this._roleRepository.Find(id);

        return role;
    }

    public async Task<Role> Create(CreateRoleDto createRoleDto) {
        Role role = this._mapper.Map<Role>(createRoleDto);

        await this._roleRepository.Create(role);

        return role;
    }

    public async Task<Role?> Update(int id, UpdateRoleDto updateRoleDto) {
        Role? role = await this._roleRepository.Find(id);

        if(role is null)
            return null;

        Role updatedRole = _mapper.Map(updateRoleDto, role);

        await this._roleRepository.Update(updatedRole);

        return role;
    }

    public async Task<bool> Delete(int id) {
        Role? role = await this._roleRepository.Find(id);

        if(role is null)
            return false;

        await this._roleRepository.Delete(role);

        return true;
    }
}