using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy
{
    public class AgentMoveToHero : Follow
    {
        private const float MinimalDistance = 1;

        [SerializeField] private NavMeshAgent _agent;

        private Transform _heroTransform;

        private void Update()
        {
            if (Initialized() && HeroNotReached())
                _agent.destination = _heroTransform.position;
        }

        public void Construct(Transform heroTransform)
        {
            _heroTransform = heroTransform;
        }

        private bool Initialized() =>
            _heroTransform != null;

        private bool HeroNotReached() =>
            Vector3.Distance(_agent.transform.position, _heroTransform.position) >= MinimalDistance;
    }
}