using UnityEngine;
using ZombieAttack.Abstracts.Combats;
using ZombieAttack.Combats;

namespace ZombieAttack.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Attack Info", menuName = "Combat/Attack Information/Create New", order = 51)]
    public class AttackSO : ScriptableObject
    {
        [SerializeField] private int damage = 10;
        [SerializeField] private float floatValue = 1f;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float attackMaxDelay = 0.25f;
        [SerializeField] private AnimatorOverrideController animatorOverride;
        [SerializeField] private AudioClip audioClip;

        public int Damage => damage;
        public float FloatValue => floatValue;
        public LayerMask LayerMask => layerMask;
        public float AttackMaxDelay => attackMaxDelay;
        public AnimatorOverrideController AnimatorOverride => animatorOverride;
        public AudioClip AudioClip => audioClip;
        
    }
}
