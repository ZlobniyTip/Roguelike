using Random = UnityEngine.Random;

namespace Assets.Scripts.Services.Randomizer
{
    public class RandomService : IRandomService
    {
        public int Next(int min, int max) =>
          Random.Range(min, max);
    }
}