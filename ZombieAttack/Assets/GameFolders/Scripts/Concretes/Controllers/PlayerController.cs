using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Combats;
using ZombieAttack.Abstracts.Controllers;
using ZombieAttack.Abstracts.Inputs;
using ZombieAttack.Abstracts.Movements;
using ZombieAttack.Animation;
using ZombieAttack.Managers;
using ZombieAttack.Movements;

namespace ZombieAttack.Controllers
{
    public class PlayerController : MonoBehaviour , IEntityController
    {
        [Header("Movement Informations")]
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float turnSpeed = 10f;
        [SerializeField] private Transform turnTransform;

        [Header("UIs")]
        [SerializeField] private GameObject gameOverPanel;
        
        private IInputReader _input;
        private IMover _mover;
        private CharacterAnimation _animation;
        private IHealth _health;
        private IRotator _xRotator;
        private IRotator _yRotator;
        private Vector3 _direction;
        private Vector2 _rotation;
        private InventoryController _inventory;

        public Transform TurnTransform => turnTransform;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _health = GetComponent<IHealth>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorXCharacter(this);
            _yRotator = new RotatorYCharacter(this);
            _inventory = GetComponent<InventoryController>();
        }

        private void OnEnable()
        {
            _health.OnDead += () =>
            {
                _animation.DeadAnimation();
                gameOverPanel.SetActive(true);
            };
            
            EnemyManager.Instance.Targets.Add(this.transform);
        }

        private void OnDisable()
        {
            EnemyManager.Instance.Targets.Remove(this.transform);
        }


        private void Update()
        {
            if(_health.IsDead) return;
            
            _direction = _input.Direction;
            _xRotator.RotationAction(_input.Rotation.x, turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y,turnSpeed);

            if (_input.IsAttackButtonPressed)
            {
                _inventory.CurrentWeapon.Attack();
            }

            if (_input.IsInventoryButtonPressed)
            {
                _inventory.ChangeWeapon();
            }
        }

        private void FixedUpdate()
        {
            if(_health.IsDead) return;
            
            _mover.MoveAction(_direction , moveSpeed);
        }

        private void LateUpdate()
        {
            if(_health.IsDead) return;
            
            _animation.MoveAnimation(_direction.magnitude);
            _animation.AttackAnimation(_input.IsAttackButtonPressed);
        }
        
    }
}

