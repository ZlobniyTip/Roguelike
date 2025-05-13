using Assets.Scripts.Infrastructure.Services;

namespace Assets.Scripts.Services.Randomizer
{
    public interface IRandomService : IService
    {
        int Next(int minValue, int maxValue);
    }
}