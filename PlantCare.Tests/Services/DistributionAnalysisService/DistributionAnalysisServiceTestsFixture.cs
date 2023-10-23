using AutoFixture;
using PlantCare.Tests.Configuration;

namespace PlantCare.Tests.Services.DistributionAnalysisService;

[CollectionDefinition((nameof(DistributionAnalysisServiceTestsFixture)))]
public class DistributionAnalysisServiceTestsFixture : BaseTestsCollectionFixture, ICollectionFixture<DistributionAnalysisServiceTestsFixture>
{
    public override IFixture GetPreconfiguredAutoFixture()
    {
        _autoFixture = base.GetPreconfiguredAutoFixture();

        return _autoFixture;
    }
}