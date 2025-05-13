using Assets.Scripts.Logic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;

        private IHealth _health;

        private void Start()
        {
            IHealth health = GetComponent<IHealth>();

            if (health != null)
                Construct(health);
        }

        private void OnDestroy() =>
            _health.HealthChanged -= UpdateHealthBar;

        public void Construct(IHealth health)
        {
            _health = health;

            _health.HealthChanged += UpdateHealthBar;
        }

        private void UpdateHealthBar()
        {
            _healthBar.SetValue(_health.Current, _health.Max);
        }
    }
}