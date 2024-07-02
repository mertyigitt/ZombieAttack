using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Combats;
using ZombieAttack.ScriptableObjects;

namespace ZombieAttack.Combats
{
    public class Health : MonoBehaviour , IHealth
    {
        [SerializeField] private HealthSO healthInfo;

        private int _currentHealth;

        public event Action<int, int> OnTakeHit;
        public event Action OnDead;

        public bool IsDead => _currentHealth <= 0;

        private void Awake()
        {
            _currentHealth = healthInfo.MaxHealth;
        }

        public void TakeDamage(int damage)
        {
            if(IsDead) return;
            
            _currentHealth -= damage;
            
            OnTakeHit?.Invoke(_currentHealth,healthInfo.MaxHealth);
            if (IsDead)
            {
                OnDead?.Invoke();  
            }
        }
    }
}
