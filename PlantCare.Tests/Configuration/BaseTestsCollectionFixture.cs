using AutoFixture;
using AutoFixture.AutoMoq;
using PlantCare.Tests.Interfaces;

namespace PlantCare.Tests.Configuration;
public class BaseTestsCollectionFixture : IPlantCareTestFixture
{
    protected IFixture _autoFixture;

    public virtual IFixture GetPreconfiguredAutoFixture()
    {
        _autoFixture = new Fixture()
            .Customize(new AutoMoqCustomization());

        return _autoFixture;
    }
}

