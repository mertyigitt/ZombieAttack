using UnityEngine;
using ZombieAttack.Abstracts.Combats;
using ZombieAttack.ScriptableObjects;

namespace ZombieAttack.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        
        [SerializeField] private bool canFire;
        
        private float _currentTime;
        private IAttackType _attackType;
        public AnimatorOverrideController AnimatorOverrideController => _attackType.AttackInfo.AnimatorOverride;

        private void Awake()
        {
            _attackType = GetComponent<IAttackType>();
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            canFire = _currentTime > _attackType.AttackInfo.AttackMaxDelay;
        }
        
        public void Attack()
        {
            if (!canFire) return;
            
            _attackType.AttackAction();
            
            _currentTime = 0f;
        }
    }
}
