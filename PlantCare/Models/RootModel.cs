namespace PlantCare.Models;

/// <summary>
/// Good practice to add summary for each property
/// but for demo purposes summaries are not added.
/// </summary>
/// <typeparam name="T"></typeparam>
public class RootModel<T> where T : class
{
    public T Data { get; init; }
}