using UnityEngine;
using ZombieAttack.Abstracts.Combats;
using ZombieAttack.Combats;
using ZombieAttack.ScriptableObjects;

namespace ZombieAttack.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        
        [SerializeField] private bool canFire;
        [SerializeField] private Transform transformObject;
        [SerializeField] private AttackSO attackSo;
        
        private float _currentTime;
        private IAttackType _attackType;

        private void Awake()
        {
            _attackType = attackSo.GetAttackType(transformObject);
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            canFire = _currentTime > attackSo.AttackMaxDelay;
        }
        
        public void Attack()
        {
            if (!canFire) return;
            
            _attackType.AttackAction();
            
            _currentTime = 0f;
        }
    }
}
