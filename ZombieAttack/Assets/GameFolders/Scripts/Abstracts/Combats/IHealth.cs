using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieAttack.Abstracts.Combats
{
    public interface IHealth
    {
        bool IsDead { get; }
        void TakeDamage(int damage);
        event Action OnDead;
    }
}
