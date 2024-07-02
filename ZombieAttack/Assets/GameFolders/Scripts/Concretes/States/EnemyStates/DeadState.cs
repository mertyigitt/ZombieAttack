using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Controllers;
using ZombieAttack.Abstracts.States;

namespace ZombieAttack.States.EnemyStates
{
    public class DeadState : IState
    {
        private IEnemyController _enemyController;
        private float _currentTime;
        private float _maxTime = 5f;
        public DeadState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            _enemyController.Dead.DeadAction();
            _enemyController.Animation.DeadAnimation();
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            return;
        }

        public void FixedTick()
        {
            return;
        }

        public void LateTick()
        {
            return;
        }
    }
}
