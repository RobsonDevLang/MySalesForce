using Moq;
using Product.DTO;
using Product.Repositories;
using Product.Services;

namespace Product.Service.Tests;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _repositoryMock;
    private readonly ProductService _service;

    public ProductServiceTests()
    {
        _repositoryMock = new Mock<IProductRepository>();

        _service = new ProductService(
            _repositoryMock.Object);
    }

    [Fact]
    public void GetAllActive_ShouldReturnProductsReturnedByRepository()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new()
            {
                Code = "001",
                Name = "Notebook",
                Status = 1
            }
        };

        _repositoryMock
            .Setup(x => x.GetAllActive())
            .Returns(products);

        // Act
        var result = _service.GetAllActive();

        // Assert
        Assert.Single(result);
        Assert.Equal("Notebook", result[0].Name);
    }

    [Fact]
    public void GetAllActive_ShouldReturnEmptyList()
    {
        // Arrange
        _repositoryMock
            .Setup(x => x.GetAllActive())
            .Returns(new List<ProductDto>());

        // Act
        var result = _service.GetAllActive();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetAllActive_ShouldCallRepositoryOnce()
    {
        // Arrange
        _repositoryMock
            .Setup(x => x.GetAllActive())
            .Returns(new List<ProductDto>());

        // Act
        _service.GetAllActive();

        // Assert
        _repositoryMock.Verify(
            x => x.GetAllActive(),
            Times.Once);
    }

    [Fact]
    public void GetAllActive_ShouldReturnAllProductsReturnedByRepository()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { Code = "001", Name = "Notebook", Status = 1 },
            new() { Code = "002", Name = "Mouse", Status = 1 },
            new() { Code = "003", Name = "Teclado", Status = 0 }
        };

        _repositoryMock
            .Setup(x => x.GetAllActive())
            .Returns(products);

        // Act
        var result = _service.GetAllActive();

        // Assert
        Assert.Equal(3, result.Count);
    }
}