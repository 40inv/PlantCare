using PlantCare.Models;

namespace PlantCare.Services.Interfaces;

/// <summary>
/// Service for plant analysis.
/// Dummy methods to show async/await, linq, etc.
/// </summary>
public interface IPlantAnalysisService
{
    /// <summary>
    /// Async method that shows semaphore usage.
    /// </summary>
    /// <param name="numberOfTasks">Number of tasks that should be created.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Returns analyzed result.</returns>
    public Task<PlantAnalysisResult> DistributionAnalyticsAsync(int numberOfTasks, CancellationToken cancellationToken);
}