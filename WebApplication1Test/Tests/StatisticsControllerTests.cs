namespace WebApplication1Test.Tests;

using Xunit;
using Microsoft.Extensions.Logging;
using Moq;
using WebApplication1Test.Controllers;
using WebApplication1Test.Models;
using Microsoft.AspNetCore.Mvc;

public class StatisticsControllerTests
{
    private readonly Mock<ILogger<StatisticsController>> _mockLogger = new Mock<ILogger<StatisticsController>>();
    private readonly StatisticsController _controller;

    public StatisticsControllerTests()
    {
        // Create a mock logger
        _mockLogger = new Mock<ILogger<StatisticsController>>();
        
        // Instantiate your controller with the mock logger
        _controller = new StatisticsController();
    }

    [Fact]
    public void Post_ValidNumbers_ReturnsCorrectStatistics()
    {
        // Arrange
        var input = new StatisticsInput { Numbers = new List<int> { 1, 2, 3, 4, 5 } };
        
        // Act
        var actionResult = _controller.Post(input);
        
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var statisticsResults = Assert.IsType<StatisticsResults>(okResult.Value);
        Assert.Equal(15, statisticsResults.Sum);
        Assert.Equal(3, statisticsResults.Average);
        Assert.Equal(3, statisticsResults.Median);
        Assert.Equal(1, statisticsResults.Mode); // Depending on how mode is calculated, this may vary.
    }

    // ...additional tests for invalid inputs, boundary conditions, etc.
}
