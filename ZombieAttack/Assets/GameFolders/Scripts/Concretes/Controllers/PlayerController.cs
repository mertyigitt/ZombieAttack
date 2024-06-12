using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Controllers;
using ZombieAttack.Abstracts.Inputs;
using ZombieAttack.Abstracts.Movements;
using ZombieAttack.Animation;
using ZombieAttack.Movements;

namespace ZombieAttack.Controllers
{
    public class PlayerController : MonoBehaviour , IEntityController
    {
        [Header("Movement Informations")]
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float turnSpeed = 10f;
        [SerializeField] private Transform turnTransform;
        [SerializeField] private WeaponController currentWeapon;
        
        private IInputReader _input;
        private IMover _mover;
        private CharacterAnimation _animation;
        private IRotator _xRotator;
        private IRotator _yRotator;
        private Vector3 _direction;
        private Vector2 _rotation;

        public Transform TurnTransform => turnTransform;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorXCharacter(this);
            _yRotator = new RotatorYCharacter(this);
        }

        private void Update()
        {
            _direction = _input.Direction;
            _xRotator.RotationAction(_input.Rotation.x, turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y,turnSpeed);

            if (_input.IsAttackButtonPressed)
            {
                currentWeapon.Attack();
            }
        }

        private void FixedUpdate()
        {
            _mover.MoveAction(_direction , moveSpeed);
        }

        private void LateUpdate()
        {
            _animation.MoveAnimation(_direction.magnitude);
        }
        
    }
}

