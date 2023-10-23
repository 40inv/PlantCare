using AutoFixture;
using FluentAssertions;
using PlantCare.Models;
using PlantCare.Services.Implementation;

namespace PlantCare.Tests.Services.DistributionAnalysisService;

[Collection(nameof(DistributionAnalysisServiceTestsFixture))]
public class ServiceTests
{
    private readonly PlantAnalysisService _service;
    private IFixture _autoFixture;
    private readonly DistributionAnalysisServiceTestsFixture _fixture;

    public ServiceTests(DistributionAnalysisServiceTestsFixture fixture)
    {
        _fixture = fixture;
        _autoFixture = _fixture.GetPreconfiguredAutoFixture();
        _service = _autoFixture.Create<PlantAnalysisService>();
    }

    [Fact]
    public async Task ServiceDistributionAnalyticsAsync_WhenNegativeNumberOfTasksIsPassed_ReturnsEmptyResult()
    {
        // Arrange
        var numberOfTasks = -1;

        // Act
        PlantAnalysisResult result = await _service.DistributionAnalyticsAsync(numberOfTasks, default);

        // Assert
        result.Should().NotBeNull();
        result.SpeciesCount.Should().Be(0);
    }

    [Fact]
    public async Task ServiceDistributionAnalyticsAsync_WhenValidNumberIsPassed_ReturnFilledResult()
    {
        // Arrange
        var numberOfTasks = 3;

        // Act
        PlantAnalysisResult result = await _service.DistributionAnalyticsAsync(numberOfTasks, default);

        // Assert
        result.Should().NotBeNull();
        result.SpeciesCount.Should().BeGreaterThan(1);

    }

    [Theory]
    [InlineData(10)]
    [InlineData(20)]
    public async Task ServiceDistributionAnalyticsAsync_WhenNumberOfTasksThatBiggerThanSemaphoreMaxCountIsPassed_ReturnFilledResult(int numberOfTasks)
    {
        // Arrange

        // Act
        PlantAnalysisResult result = await _service.DistributionAnalyticsAsync(numberOfTasks, default);

        // Assert
        result.Should().NotBeNull();
        result.SpeciesCount.Should().BeGreaterThan(1);

    }
}