using System;
using Assets.Scripts.Enemy;
using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent (typeof(EnemyHealth))]
[RequireComponent (typeof(EnemyAnimator))]
[RequireComponent (typeof(AgentMoveToHero))]
public class EnemyDeath : MonoBehaviour
{
    private const int DelayBetweenDeath = 3;

    [SerializeField] private GameObject _deathFx;

    private Attack _attack;
    private AgentMoveToHero _move;
    private EnemyAnimator _animator;
    private EnemyHealth _health;

    public event Action Happened;

    private void Awake()
    {
        _attack = GetComponent<Attack>();   
        _move = GetComponent<AgentMoveToHero>();
        _health = GetComponent<EnemyHealth>();
        _animator = GetComponent<EnemyAnimator>();
    }

    private void Start() => 
        _health.HealthChanged += HealthChanged;

    private void OnDestroy() =>
        _health.HealthChanged -= HealthChanged;

    private void HealthChanged()
    {
        if (_health.Current <= 0)
            Die();
    }

    private void Die()
    {
        _attack.enabled = false;
        _move.enabled = false;
        _health.HealthChanged -= HealthChanged;
        _animator.PlayDeath();

        Instantiate(_deathFx, transform);
        DestroyTimer().Forget();

        Happened?.Invoke();
    }

    async private UniTaskVoid DestroyTimer()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(DelayBetweenDeath));

        Destroy(gameObject);
    }
}