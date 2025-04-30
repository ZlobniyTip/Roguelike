using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Logic;
using Assets.Scripts.Services.Input;
using Scripts.Infrastructure;

namespace Assets.Scripts.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain, AllServices.Container);
        }
    }
}