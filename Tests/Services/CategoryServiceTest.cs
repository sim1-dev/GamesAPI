using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Repositories;
using GamesAPI.Services;
using Moq;
using Xunit; 

namespace GamesAPI.Tests;

public class CategoryServiceTest {

    private readonly Mock<ICategoryRepository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;

    public CategoryServiceTest() {
        this._mockRepository = new Mock<ICategoryRepository>();
        this._mockMapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task Should_Return_Categories() {
        IEnumerable<Category> categories = [
            new Category { Id = 1, Name = "Test Category" },
            new Category { Id = 2, Name = "Test Category 2" }
        ];

        this._mockRepository.Setup(categoryRepository => categoryRepository.Get(null, null, null)).ReturnsAsync(categories);

        CategoryService categoryService = new CategoryService(this._mockRepository.Object, this._mockMapper.Object);

        IEnumerable<Category> result = await categoryService.Get(null, null, null);

        Assert.NotNull(result);
        Assert.Equal(categories, result);
    }

    [Fact]
    public async Task Should_Return_Category_When_Category_Found() {
        Category category = new Category { Id = 1, Name = "Test Category" };

        this._mockRepository.Setup(categoryRepository => categoryRepository.Find(1)).ReturnsAsync(category);

        CategoryService categoryService = new CategoryService(this._mockRepository.Object, this._mockMapper.Object);

        Category? result = await categoryService.Find(1);

        Assert.NotNull(result);
        Assert.Equal(category.Id, result.Id);
        Assert.Equal(category.Name, result.Name);
    }

    [Fact]
    public async Task Should_Return_Null_When_Category_Not_Found() {
        this._mockRepository.Setup(categoryRepository => categoryRepository.Find(1)).ReturnsAsync((Category?)null);

        CategoryService categoryService = new CategoryService(this._mockRepository.Object, this._mockMapper.Object);

        Category? result = await categoryService.Find(1);

        Assert.Null(result);
    }

    [Fact]
    public async Task Should_Delete_Category_When_Category_Found() {
        Category category = new Category { Id = 1, Name = "Test Category" };

        this._mockRepository.Setup(categoryRepository => categoryRepository.Find(1)).ReturnsAsync(category);
        this._mockRepository.Setup(categoryRepository => categoryRepository.Delete(category));

        CategoryService categoryService = new CategoryService(this._mockRepository.Object, this._mockMapper.Object);

        bool result = await categoryService.Delete(1);

        this._mockRepository.Verify(categoryRepository => categoryRepository.Delete(category), Times.Once);

        Assert.True(result);
    }

    [Fact]
    public async Task Should_Delete_Return_False_When_Category_Not_Found() {
        this._mockRepository.Setup(categoryRepository => categoryRepository.Find(1)).ReturnsAsync((Category?)null);

        CategoryService categoryService = new CategoryService(this._mockRepository.Object, this._mockMapper.Object);

        bool result = await categoryService.Delete(1);

        Assert.False(result);
    }

}