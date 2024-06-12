using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ZombieAttack.Abstracts.Controllers;
using ZombieAttack.Abstracts.Movements;
using ZombieAttack.Animation;
using ZombieAttack.Movements;

namespace ZombieAttack.Controllers
{
    public class EnemyController : MonoBehaviour , IEntityController
    {
        [SerializeField] private Transform playerPrefab;
        private IMover _mover;
        private CharacterAnimation _animation;
        NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            _mover.MoveAction(playerPrefab.transform.position, 10f);
        }

        private void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
        }
    }
}