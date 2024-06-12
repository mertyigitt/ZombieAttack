using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.ScriptableObjects;

namespace ZombieAttack.Helpers
{
    public class MeleeAttackRangeDisplay : MonoBehaviour
    {
        [SerializeField] private AttackSO attackSo;
        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(this.transform.position, attackSo.FloatValue);
        }
    }
}
