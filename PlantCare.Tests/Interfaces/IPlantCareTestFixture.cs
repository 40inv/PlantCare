using AutoFixture;

namespace PlantCare.Tests.Interfaces;

public interface IPlantCareTestFixture
{
    IFixture GetPreconfiguredAutoFixture();
}
