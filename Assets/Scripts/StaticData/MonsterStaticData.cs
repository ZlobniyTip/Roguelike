using Assets.Scripts.Logic;
using UnityEngine;

namespace Assets.Scripts.StaticData
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "StaticData/Monster")]
    public class MonsterStaticData : ScriptableObject
    {
        public MonsterTypeId MonsterTypeId;

        [Range(1, 100)]
        public int Hp;

        [Range(1f, 30)]
        public float Damage;
        
        [Range(0.5f, 5)]
        public float MoveSpeed;

        [Range(0.5f, 2)]
        public float EffectiveDistance = 0.7f;

        [Range(0.5f, 1)]
        public float Cleavage;

        public int MaxLoot;
        public int MinLoot;

        public GameObject Prefab;
    }
}