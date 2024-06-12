using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Controllers;
using ZombieAttack.Abstracts.Movements;
using ZombieAttack.Movements;

namespace ZombieAttack.Controllers
{
    public class EnemyController : MonoBehaviour , IEntityController
    {
        [SerializeField] private Transform playerPrefab;
        private IMover _mover;
        private IEntityController _entityControllerImplementation;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
        }

        private void Update()
        {
            _mover.MoveAction(playerPrefab.transform.position, 10f);
        }
        
    }
}
