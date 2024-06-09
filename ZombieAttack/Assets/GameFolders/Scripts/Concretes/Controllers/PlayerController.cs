using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Inputs;
using ZombieAttack.Abstracts.Movements;
using ZombieAttack.Animation;
using ZombieAttack.Movements;

namespace ZombieAttack.Controllers
{
    public class PlayerController : MonoBehaviour 
    {
        [Header("Movement Informations")]
        [SerializeField] private float moveSpeed = 10f;
        
        private IInputReader _input;
        private IMover _mover;
        private CharacterAnimation _animation;
        private Vector3 _direction;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
        }

        private void Update()
        {
            _direction = _input.Direction;
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

