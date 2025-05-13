using Assets.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Assets.Scripts.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp { get; }

        bool AttackButtonUp();
    }
}