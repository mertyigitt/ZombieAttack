using UnityEngine;
using ZombieAttack.Abstracts.Combats;
using ZombieAttack.Managers;
using ZombieAttack.ScriptableObjects;

namespace ZombieAttack.Combats
{
    public class MeleeAttackType : IAttackType
    {
        private Transform _transformObject;
        AttackSO _attackSo;
        
        public MeleeAttackType(Transform transformObject, AttackSO attackSo)
        {
            _transformObject = transformObject;
            _attackSo = attackSo;
        }
        public void AttackAction()
        {
            Vector3 attackPoint = _transformObject.position;
            Collider[] colliders = Physics.OverlapSphere(attackPoint, _attackSo.FloatValue, _attackSo.LayerMask);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSo.Damage);
                }
            }
            SoundManager.Instance.MeleeAttackSound(_attackSo.AudioClip, _transformObject.position);
        }
    }
}
