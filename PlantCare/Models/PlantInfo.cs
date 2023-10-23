using static System.Net.Mime.MediaTypeNames;

namespace PlantCare.Models;

/// <summary>
/// Good practice to add summary for each property
/// but for demo purposes summaries are not added.
/// </summary>
public record PlantInfo()
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
    public string Family { get; init; }
    public int GenusId { get; init; }
    public string Genus { get; init; }
    public string ImageUrl { get; init; }
    public PlantLink Links { get; init; }
    public List<string> Duration { get; init; }
    public List<string> EdiblePart { get; init; }
    public bool? Edible { get; init; }
    public bool? Vegetable { get; init; }
    public string Observations { get; init; }
    public Images Images { get; init; }
    public object CommonNames { get; init; }
    public object Distribution { get; init; }
    public Distributions Distributions { get; init; }
    public object Flower { get; init; }
    public object Foliage { get; init; }
    public object FruitOrSeed { get; init; }
    public object Specifications { get; init; }
    public object Growth { get; init; }
    public List<object> Synonyms { get; init; }
    public List<object> Sources { get; init; }
    public object Extras { get; init; }
}

#region HelperRecords

/// <summary>
/// Good practice to add summary for each property
/// but for demo purposes summaries are not added.
/// </summary>
public record Distributions
{
    public List<PlantDistribution> Native { get; init; }
    public List<PlantDistribution> Introduced { get; init; }
    public List<PlantDistribution> Doubtful { get; init; }
    public List<PlantDistribution> Absent { get; init; }
    public List<PlantDistribution> Extinct { get; init; }

}

/// <summary>
/// Good practice to add summary for each property
/// but for demo purposes summaries are not added.
/// </summary>
public record PlantDistribution
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Slug { get; init; }
    public string TdwgCode { get; init; }
    public int TdwgLevel { get; init; }
    public int SpeciesCount { get; init; }
}

/// <summary>
/// Good practice to add summary for each property
/// but for demo purposes summaries are not added.
/// </summary>
public record Images
{
    public List<Image> Flower { get; init; }
    public List<Image> Leaf { get; init; }
    public List<Image> Habit { get; init; }
    public List<Image> Fruit { get; init; }
    public List<Image> Bark { get; init; }
    public List<Image> Other { get; init; }
}

/// <summary>
/// Good practice to add summary for each property
/// but for demo purposes summaries are not added.
/// </summary>
public record Image
{
    public string Id { get; init; }
    public string ImageUrl { get; init; }
    public string Copyright { get; init; }
}

#endregion

