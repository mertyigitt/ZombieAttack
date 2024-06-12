using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieAttack.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Health Info", menuName = "Health Information/Create New", order = 51)]
    public class HealthSO : ScriptableObject
    {
        [SerializeField] private int maxHealth;
        public int MaxHealth => maxHealth;
    }
}
