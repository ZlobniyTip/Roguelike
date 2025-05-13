using System.Linq;
using Assets.Scripts.Logic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class Attack : MonoBehaviour
    {
        [SerializeField] private float _cooldown = 3f;
        [SerializeField] private float _cleavage = 0.5f;
        [SerializeField] private float _effectiveDistance = 0.5f;
        [SerializeField] private float _damage = 10f;

        private EnemyAnimator _animator;
        private Transform _heroTranfsorm;
        private float _attackCooldown;
        private bool _isAttacking;
        private int _layerMask;
        private Collider[] _hits = new Collider[1];
        private bool _attackIsActive;

        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer("Player");
            _animator = GetComponent<EnemyAnimator>();
        }

        private void Update()
        {
            UpdateCooldown();

            if (CanAttack())
                StartAttack();
        }

        public void Construct(Transform heroTransform, float damage, float cleavage, float effectiveDistance)
        {
            _heroTranfsorm = heroTransform;
            _damage = damage;
            _cleavage = cleavage;
            _effectiveDistance = effectiveDistance;
        }

        public void EnableAttack() =>
            _attackIsActive = true;

        public void DisableAttack() =>
            _attackIsActive = false;

        private void OnAttack()
        {
            if (Hit(out Collider hit))
            {
                PhysicsDebug.DrawDebug(StartPoint(), _cleavage, 1f);
                hit.transform.GetComponent<IHealth>().TakeDamage(_damage);
            }
        }

        private bool Hit(out Collider hit)
        {
            int hitsCount = Physics.OverlapSphereNonAlloc(StartPoint(), _cleavage, _hits, _layerMask);

            hit = _hits.FirstOrDefault();
            return hitsCount > 0;
        }

        private Vector3 StartPoint() =>
            new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z)
            + transform.forward * _effectiveDistance;

        private void OnAttackEnded()
        {
            _attackCooldown = _cooldown;
            _isAttacking = false;
        }

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _attackCooldown -= Time.deltaTime;
        }

        private bool CooldownIsUp()
        {
            return _attackCooldown <= 0;
        }

        private void StartAttack()
        {
            transform.LookAt(_heroTranfsorm);
            _animator.PlayAttack();

            _isAttacking = true;
        }

        private bool CanAttack() =>
             _attackIsActive && !_isAttacking && CooldownIsUp();
    }
}