using Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(HeroHealth))]
    public class HeroDeath : MonoBehaviour
    {
        [SerializeField] private GameObject _deathFx;

        private HeroAttack _attack;
        private HeroHealth _health;
        private HeroMove _move;
        private HeroAnimator _animator;
        private bool _isDead;

        private void Awake()
        {
            _health = GetComponent<HeroHealth>();
            _move = GetComponent<HeroMove>();
            _animator = GetComponent<HeroAnimator>();
            _attack = GetComponent<HeroAttack>();
        }

        private void Start() =>
            _health.HealthChanged += HealthChanged;

        private void OnDestroy() =>
            _health.HealthChanged -= HealthChanged;

        private void HealthChanged()
        {
            if (!_isDead && _health.Current <= 0)
                Die();
        }

        private void Die()
        {
            _isDead = true;
            _attack.enabled = false;
            _move.StopMoving();
            _animator.PlayDeath();

            Instantiate(_deathFx, transform.position, Quaternion.identity);
        }
    }
}