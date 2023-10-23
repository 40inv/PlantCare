namespace PlantCare.Models;

/// <summary>
/// Good practice to add summary for each property
/// but for demo purposes summaries are not added.
/// </summary>
public class DetailedPlantModel
{
    public int Id { get; init; }
    public string CommonName { get; init; }
    public string Slug { get; init; }
    public string ScientificName { get; init; }
    public int? MainSpeciesId { get; init; }
    public object ImageUrl { get; init; }
    public int? Year { get; init; }
    public string Bibliography { get; init; }
    public string Author { get; init; }
    public string FamilyCommonName { get; init; }
    public int? GenusId { get; init; }
    public string Observations { get; init; }
    public bool? Vegetable { get; init; }
    public PlantLink Links { get; init; }
    public PlantInfo MainSpecies { get; init; }
    public object Genus { get; init; }
    public object Family { get; init; }
    public List<object> Species { get; init; }
    public List<object> Subspecies { get; init; }
    public List<object> Varieties { get; init; }
    public List<object> Hybrids { get; init; }
    public List<object> Forms { get; init; }
    public List<object> Subvarieties { get; init; }
    public List<object> Sources { get; init; }
}