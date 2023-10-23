using PlantCare.Models;
using PlantCare.Services.Interfaces;

namespace PlantCare.Services.Implementation;

/// <inheritdoc />
public class PlantAnalysisService : IPlantAnalysisService
{
    private readonly SemaphoreSlim _semaphoreSlim = new( 0, 3);

    /// <inheritdoc />
    public async Task<PlantAnalysisResult> DistributionAnalyticsAsync(int numberOfTasks, CancellationToken cancellationToken)
    {
        if (numberOfTasks < 0)
        {
            return new PlantAnalysisResult();
        }

        var tasks = new List<Task<PlantAnalysisResult>>();

        for (int i = 0; i <= numberOfTasks; i++)
        {
            tasks.Add(AnalyzeAsync(cancellationToken));  
        }

        _ = _semaphoreSlim.Release(3);
        PlantAnalysisResult[] results = await Task.WhenAll(tasks);

        return results.OrderByDescending(obj => obj.SpeciesCount).First();
    }

    private async Task<PlantAnalysisResult> AnalyzeAsync(CancellationToken cancellationToken)
    {
        // Simulate asynchronous work
        await _semaphoreSlim.WaitAsync(cancellationToken);

        try
        {
            Console.WriteLine("Task {0} enters the semaphore.", Task.CurrentId);

            // Simulation of api call or something async 
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
        }
        finally
        {
            _ = _semaphoreSlim.Release();
        }

        // Analyze the distribution and update the distribution data
        var result = new PlantAnalysisResult
        {
            SpeciesCount = new Random().Next(1000, 5000) // Simulated analysis result
        };

        return result;
    }

}