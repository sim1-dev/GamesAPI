using AutoMapper;
using GamesAPI.Core.Models;
using GamesAPI.Dtos;

namespace GamesAPI.Utilities;
class CategoryProfile : Profile {
    public CategoryProfile() {
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
        
        CreateMap<Category, CategoryDto>();

        CreateMap<Category, CategoryDetailDto>()
            .ForMember(CategoryDetailDto => CategoryDetailDto.GameDtos, opt => opt.MapFrom(category => category.Games))
        ;
    }
}