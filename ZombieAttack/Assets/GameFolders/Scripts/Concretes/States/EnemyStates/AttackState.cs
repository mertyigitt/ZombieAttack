using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ZombieAttack.Abstracts.Controllers;
using ZombieAttack.Abstracts.States;

namespace ZombieAttack.States.EnemyStates
{
    public class AttackState : IState
    {
        private IEnemyController _enemyController;
        public AttackState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            Debug.Log($"{nameof(AttackState)} {nameof(OnEnter)}");
        }

        public void OnExit()
        {
            _enemyController.Animation.AttackAnimation(false);
        }

        public void Tick()
        {
            _enemyController.transform.LookAt(_enemyController.Target);
            _enemyController.transform.eulerAngles = new Vector3(0f, _enemyController.transform.eulerAngles.y, 0f);
        }

        public void FixedTick()
        {
            _enemyController.Inventory.CurrentWeapon.Attack();
        }

        public void LateTick()
        {
            _enemyController.Animation.AttackAnimation(true);
        }
    }
}
