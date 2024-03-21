using AutoMapper;
using GamesAPI.Core.DataContexts;
using GamesAPI.Models;
using GamesAPI.Core.Services;
using GamesAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Services;

public class SoftwareHouseService : ICrudService<SoftwareHouse, SoftwareHouseDto, CreateSoftwareHouseDto, UpdateSoftwareHouseDto> {

    private readonly BaseContext _db;
    private readonly IMapper _mapper;

    public SoftwareHouseService(BaseContext db, IMapper mapper) {
        this._db = db;
        this._mapper = mapper;
    }

    public async Task<List<SoftwareHouse>> GetAll() {
        return await _db.SoftwareHouses.ToListAsync();
    }
    
    public async Task<SoftwareHouse?> Find(int id) {
        SoftwareHouse? softwareHouse = await _db.SoftwareHouses
            .Include(softwareHouse => softwareHouse.Developers)
        .FirstOrDefaultAsync(softwareHouse => softwareHouse.Id == id);

        return softwareHouse;
    }

    public async Task<List<SoftwareHouse>> FindByIds(List<int> ids) {
        return await _db.SoftwareHouses.Where(softwareHouse => ids.Contains(softwareHouse.Id)).ToListAsync();
    }

    public async Task<SoftwareHouse> Create(CreateSoftwareHouseDto createSoftwareHouseDto) {
        SoftwareHouse softwareHouse = this._mapper.Map<SoftwareHouse>(createSoftwareHouseDto);

        this._db.SoftwareHouses.Add(softwareHouse);

        await _db.SaveChangesAsync();

        return softwareHouse;
    }

    public async Task<SoftwareHouse?> Update(int id, UpdateSoftwareHouseDto updateSoftwareHouseDto) {

        SoftwareHouse? softwareHouse = await this.Find(id);

        if(softwareHouse is null)
            return null;

        this._db.Entry(softwareHouse).CurrentValues.SetValues(updateSoftwareHouseDto);

        await this._db.SaveChangesAsync();

        return softwareHouse;
    }

    public async Task<SoftwareHouse?> Delete(int id) {
        SoftwareHouse? softwareHouse = await this.Find(id);

        if(softwareHouse is null)
            return null;

        this._db.SoftwareHouses.Remove(softwareHouse);

        await this._db.SaveChangesAsync();

        return softwareHouse;
    }

}