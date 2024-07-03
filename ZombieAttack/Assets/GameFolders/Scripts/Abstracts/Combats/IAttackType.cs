using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.ScriptableObjects;

namespace ZombieAttack.Abstracts.Combats
{
    public interface IAttackType
    {
        void AttackAction();
        public AttackSO AttackInfo { get; }
    }
}
