using Assets.Scripts.Data;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Logic;
using Assets.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Scripts.Logic.EnemySpawners
{
    public class SpawnPoint : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private MonsterTypeId _monsterTypeId;
        [SerializeField] private bool _isSlay;

        private IGameFactory _gameFactory;
        private EnemyDeath _enemyDeath;

        public string Id { get; private set; }

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        public void Initialize(string id, MonsterTypeId monsterType)
        {
            Id = id;
            _monsterTypeId = monsterType;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (progress.KillData.ClearSpawners.Contains(Id))
                _isSlay = true;
            else
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            GameObject monster = _gameFactory.CreateMonster(_monsterTypeId, transform);
            _enemyDeath = monster.GetComponent<EnemyDeath>();
            _enemyDeath.Happened += Slay;
        }

        private void Slay()
        {
            if (_enemyDeath != null)
                _enemyDeath.Happened -= Slay;

            _isSlay = true;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            if (_isSlay)
                progress.KillData.ClearSpawners.Add(Id);
        }
    }
}