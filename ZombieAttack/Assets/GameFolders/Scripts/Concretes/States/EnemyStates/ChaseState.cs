using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Controllers;
using ZombieAttack.Abstracts.States;

namespace ZombieAttack.States.EnemyStates
{
    public class ChaseState : IState
    {
        private IEnemyController _enemyController;
        private Transform _target;
        float _moveSpeed = 5f;

        public ChaseState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            Debug.Log($"{nameof(ChaseState)} {nameof(OnEnter)}");
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(ChaseState)} {nameof(OnExit)}");
            _enemyController.Mover.MoveAction(_enemyController.transform.position, 0f);
        }

        public void Tick()
        {
            _enemyController.Mover.MoveAction(_enemyController.Target.position,_moveSpeed);
        }

        public void FixedTick()
        {
            
        }

        public void LateTick()
        {
            _enemyController.Animation.MoveAnimation(_enemyController.Magnitude);
        }
    }
}
