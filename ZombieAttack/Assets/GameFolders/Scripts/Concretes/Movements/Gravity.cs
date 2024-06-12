using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieAttack.Movements
{
    [RequireComponent(typeof(CharacterController))]
    public class Gravity : MonoBehaviour
    {
        [SerializeField] float _graviy = -9.81f;
        private CharacterController _characterController;
        private Vector3 _velocity;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (_characterController.isGrounded) _velocity.y = 0f;

            _velocity.y += _graviy * Time.deltaTime;

            _characterController.Move(_velocity * Time.deltaTime);
        }
    }
}
