using GamesAPI.Core.Dtos;

namespace GamesAPI.Dtos;

public class DeveloperDetailDto : DeveloperDto {
    public required UserDto UserDto { get; set; } = null!;
    public required SoftwareHouseDto SoftwareHouseDto { get; set; } = null!;
}
