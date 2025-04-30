using Assets.Scripts.Infrastructure;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Logic;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, _loadingCurtain);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}