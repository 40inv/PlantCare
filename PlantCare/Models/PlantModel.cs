namespace PlantCare.Models;

/// <summary>
/// Good practice to add summary for each property
/// but for demo purposes summaries are not added.
/// </summary>
public record PlantModel
{
    public int Id { get; init; }
    public string CommonName { get; init; }
    public string Slug { get; init; }
    public string ScientificName { get; init; }
    public int? Year { get; init; }
    public string Bibliography { get; init; }
    public string Author { get; init; }
    public string Status { get; init; }
    public string Rank { get; init; }
    public string FamilyCommonName { get; init; }
    public int? GenusId { get; init; }
    public string ImageUrl { get; init; }
    public List<string> Synonyms { get; init; }
    public string Genus { get; init; }
    public string Family { get; init; }
    public PlantLink Links { get; init; }
}