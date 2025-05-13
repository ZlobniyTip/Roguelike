using Assets.Scripts.Data;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Services.Randomizer;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyDeath _enemyDeath;

        private IGameFactory _factory;
        private IRandomService _random;
        private int _lootMin;
        private int _lootMax;

        private void Start()
        {
            _enemyDeath.Happened += SpawnLoot;
        }

        public void Construct(IGameFactory factory, IRandomService random)
        {
            _factory = factory;
            _random = random;
        }

        public void SetLoot(int min, int max)
        {
            _lootMin = min;
            _lootMax = max;
        }

        private void SpawnLoot()
        {
            _enemyDeath.Happened -= SpawnLoot;

            LootPiece loot = _factory.CreateLoot();
            loot.transform.position = transform.position;
            Loot lootItem = GenerateLoot();

            loot.Initialize(lootItem);
        }

        private Loot GenerateLoot()
        {
            Loot loot = new Loot()
            {
                Value = _random.Next(_lootMin, _lootMax)
            };

            return loot;
        }
    }
}