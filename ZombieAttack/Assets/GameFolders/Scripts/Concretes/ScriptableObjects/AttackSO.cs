using UnityEngine;
using ZombieAttack.Abstracts.Combats;
using ZombieAttack.Combats;

namespace ZombieAttack.ScriptableObjects
{
    enum AttackTypeEnum : byte
    {
        Range,
        Melee
    }
    
    [CreateAssetMenu(fileName = "Attack Info", menuName = "Attack Information/Create New", order = 51)]
    public class AttackSO : ScriptableObject
    {
        [SerializeField] private AttackTypeEnum attackType;
        [SerializeField] private int damage = 10;
        [SerializeField] private float floatValue = 1f;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float attackMaxDelay = 0.25f;
        [SerializeField] private AnimatorOverrideController animatorOverride;

        public int Damage => damage;
        public float FloatValue => floatValue;
        public LayerMask LayerMask => layerMask;
        public float AttackMaxDelay => attackMaxDelay;
        public AnimatorOverrideController AnimatorOverride => animatorOverride;
        
        public IAttackType GetAttackType(Transform transform)
        {
            if (attackType == AttackTypeEnum.Range)
            {
                return new RangeAttackType(transform, this);
            }
            else
            {
                return new MeleeAttackType(transform, this);
            }
        }
    }
}
