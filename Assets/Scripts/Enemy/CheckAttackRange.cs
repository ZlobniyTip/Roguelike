using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(Attack))]
    public class CheckAttackRange : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;

        private Attack _attack;

        private void Start()
        {
            _attack = GetComponent<Attack>();

            _triggerObserver.TriggerEnter += TriggerEnter;
            _triggerObserver.TriggerExit += TriggerExit;

            _attack.DisableAttack();
        }

        private void TriggerExit(Collider collider)
        {
            _attack.DisableAttack();
        }

        private void TriggerEnter(Collider collider)
        {
            _attack.EnableAttack();
        }
    }
}