using Assets.Scripts.Services.Input;
using UnityEngine;
using Assets.Scripts;
using Cysharp.Threading.Tasks;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Services.PersistentProgress;
using Assets.Scripts.Data;
using UnityEngine.SceneManagement;

namespace Scripts.Player
{
    public class HeroMove : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _movementSpeed;

        private Camera _camera;
        private IInputService _input;
        private Vector3 _movementVector;

        private void Awake()
        {
            _input = AllServices.Container.Single<IInputService>();
        }

        private void Start()
        {
            _camera = Camera.main;

            Move().Forget();
        }

        private async UniTaskVoid Move()
        {
            while (true)
            {
                _movementVector = Vector3.zero;

                if (_input.Axis.sqrMagnitude > Constants.Epsilon)
                {
                    _movementVector = _camera.transform.TransformDirection(_input.Axis);
                    _movementVector.y = 0;
                    _movementVector.Normalize();

                    transform.forward = _movementVector;
                    _movementVector += Physics.gravity;
                }

                if (_controller)
                    _controller.Move(_movementVector * _movementSpeed * Time.deltaTime);

                await UniTask.NextFrame();
            }
        }

        public void UpdateProgress(PlayerProgress progress) =>
            progress.WorldData.PositionOnLevel =
                new PositionOnLevel(GetCurrentLevel(), transform.position.AsVectorData());

        private static string GetCurrentLevel() =>
             SceneManager.GetActiveScene().name;

        public void LoadProgress(PlayerProgress progress)
        {
            if (GetCurrentLevel() == progress.WorldData.PositionOnLevel.Level)
            {
                Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;

                if (savedPosition != null)
                {
                    Warp(to: savedPosition);
                }
            }
        }

        private void Warp(Vector3Data to)
        {
            _controller.enabled = false;
            transform.position = to.AsUnityVector();
            _controller.enabled = true;
        }
    }
}