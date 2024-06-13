using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ZombieAttack.Abstracts.Combats;
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
        private IHealth _health;
        private CharacterAnimation _animation;
        NavMeshAgent _navMeshAgent;
        InventoryController _inventoryController;
        private Transform _playerTransform;
        private bool _canAttack;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
            _inventoryController = GetComponent<InventoryController>();
        }

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerController>().transform;
        }
        

        private void Update()
        {
            if(_health.IsDead) return;

            _mover.MoveAction(_playerTransform.position, 10f);

            _canAttack = Vector3.Distance(_playerTransform.position, this.transform.position) <=
                         _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;
        }

        private void FixedUpdate()
        {
            if (_canAttack)
            {
                _inventoryController.CurrentWeapon.Attack();
            }
        }

        private void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
            _animation.AttackAnimation(_canAttack);
        }
    }
}
