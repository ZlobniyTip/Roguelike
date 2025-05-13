using System;
using Assets.Scripts.Logic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float _current;
        [SerializeField] private float _max;

        private EnemyAnimator _animator;

        public event Action HealthChanged;

        public float Max
        {
            get => _max;
            set => _max = value;
        }

        public float Current
        {
            get => _current;
            set => _current = value;
        }

        private void Awake()
        {
            _animator = GetComponent<EnemyAnimator>();
        }

        public void TakeDamage(float damage)
        {
            Current -= damage;

            _animator.PlayHit();

            HealthChanged?.Invoke();
        }
    }
}