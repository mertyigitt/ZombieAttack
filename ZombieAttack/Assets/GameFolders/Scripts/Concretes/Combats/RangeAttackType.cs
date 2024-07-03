using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Combats;
using ZombieAttack.Controllers;
using ZombieAttack.Managers;
using ZombieAttack.ScriptableObjects;

namespace ZombieAttack.Combats
{
    public class RangeAttackType : MonoBehaviour, IAttackType
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private AttackSO _attackSo;
        [SerializeField] private BulletFxController bulletFx;
        [SerializeField] private Transform _bulletPoint;
        
        public AttackSO AttackInfo => _attackSo;
        
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
            
            var bullet = Instantiate(bulletFx, _bulletPoint.position, _bulletPoint.rotation);
            bullet.SetDirection(ray.direction);
            
            SoundManager.Instance.RangeAttackSound(_attackSo.AudioClip, _camera.transform.position);
        }
    }
}
