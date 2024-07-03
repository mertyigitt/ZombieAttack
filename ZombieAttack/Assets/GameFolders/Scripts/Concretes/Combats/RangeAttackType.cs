using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Combats;
using ZombieAttack.Managers;
using ZombieAttack.ScriptableObjects;

namespace ZombieAttack.Combats
{
    public class RangeAttackType : IAttackType
    {
        private Camera _camera;
        private AttackSO _attackSo;
        public RangeAttackType(Transform transformObject, AttackSO attackSo)
        {
            _camera = transformObject.GetComponent<Camera>();
            _attackSo = attackSo;
        }
        public void AttackAction()
        {
            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f);
            
            if (Physics.Raycast(ray, out RaycastHit hit, _attackSo.FloatValue, _attackSo.LayerMask))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSo.Damage);
                }
            }
            SoundManager.Instance.RangeAttackSound(_attackSo.AudioClip, _camera.transform.position);
        }
    }
}
